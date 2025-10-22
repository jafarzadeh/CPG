using System;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Options.AccountGroups;
using Shouldly;
using Xunit;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class AccountDomainTests : DigitalWalletDomainTestBase
{
    [Fact]
    public async Task Change_Balance_Test()
    {
        var config = new AccountGroupConfiguration();
        var account = new Account(Guid.NewGuid(), null, "default", Guid.NewGuid(), 0, 0);
        account.Balance.ShouldBe(0m);
        account.LockedBalance.ShouldBe(0m);
        account.ChangeBalance(config, 100m);
        account.Balance.ShouldBe(100m);
        account.LockedBalance.ShouldBe(0m);
        config.AccountMinBalance = -100m;
        config.AccountMaxBalance = 150m;
        account.ChangeBalance(config, 50m);
        account.Balance.ShouldBe(150m);
        account.LockedBalance.ShouldBe(0m);
        Should.Throw<AmountOverflowException>(() => account.ChangeBalance(config, 1m));
        account.ChangeBalance(config, -250m);
        account.Balance.ShouldBe(-100m);
        account.LockedBalance.ShouldBe(0m);
        Should.Throw<AmountOverflowException>(() => account.ChangeBalance(config, -1m));
    }

    [Fact]
    public async Task Change_LockedBalance_Test()
    {
        var config = new AccountGroupConfiguration();
        var account = new Account(Guid.NewGuid(), null, "default", Guid.NewGuid(), 100m, 0);
        account.Balance.ShouldBe(100m);
        account.LockedBalance.ShouldBe(0m);
        account.ChangeLockedBalance(config, 100m);
        account.Balance.ShouldBe(100m);
        account.LockedBalance.ShouldBe(100m);
        Should.Throw<InsufficientBalanceToLockException>(() => account.ChangeLockedBalance(config, 1m));
        account.ChangeLockedBalance(config, -100m);
        account.Balance.ShouldBe(100m);
        account.LockedBalance.ShouldBe(0m);
        Should.Throw<AmountOverflowException>(() => account.ChangeLockedBalance(config, -1m));
        config.AccountMinBalance = -100m;
        config.AccountMaxBalance = 150m;
        account.ChangeBalance(config, -150m);
        account.ChangeLockedBalance(config, 50m);
        account.Balance.ShouldBe(-50m);
        account.LockedBalance.ShouldBe(50m);
        Should.Throw<InsufficientBalanceToLockException>(() => account.ChangeLockedBalance(config, 1m));
    }
}