using System;
using System.Reflection;
using JetBrains.Annotations;
using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Options.AccountGroups;

public class AccountGroupNameAttribute : Attribute
{
    public AccountGroupNameAttribute([NotNull] string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Name = name;
    }

    [NotNull] public string Name { get; }

    public virtual string GetName(Type type)
    {
        return Name;
    }

    public static string GetAccountGroupName<T>()
    {
        return GetAccountGroupName(typeof(T));
    }

    public static string GetAccountGroupName(Type type)
    {
        var nameAttribute = type.GetCustomAttribute<AccountGroupNameAttribute>();
        if (nameAttribute == null)
        {
            return type.FullName;
        }

        return nameAttribute.GetName(type);
    }
}