using System;
using System.Reflection;
using JetBrains.Annotations;
using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Options.WithdrawalMethods;

public class WithdrawalMethodNameAttribute : Attribute
{
    public WithdrawalMethodNameAttribute([NotNull] string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Name = name;
    }

    [NotNull] public string Name { get; }

    public virtual string GetName(Type type)
    {
        return Name;
    }

    public static string GetWithdrawalMethodName<T>()
    {
        return GetWithdrawalMethodName(typeof(T));
    }

    public static string GetWithdrawalMethodName(Type type)
    {
        var nameAttribute = type.GetCustomAttribute<WithdrawalMethodNameAttribute>();
        if (nameAttribute == null) return type.FullName;

        return nameAttribute.GetName(type);
    }
}