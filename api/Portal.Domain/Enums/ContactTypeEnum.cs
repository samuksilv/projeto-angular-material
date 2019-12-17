using System.ComponentModel;

namespace Portal.Domain.Enums
{
    public enum ContactTypeEnum
    {
        [Description("Email")]
        Email = 0,

        [Description("Telefone")]
        Telephone = 1,

        [Description("Whatsapp")]
        Whatsapp= 2,

    }
}