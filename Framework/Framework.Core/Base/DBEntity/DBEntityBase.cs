using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Framework.Core.Base.DBEntity
{
    public abstract class DbEntityCoreBase
    {
        [Key, Identity]
        [Column(Order = 0)]
        public int Id { get; set; }
    }

    public abstract class DbEntityBasicBase : DbEntityCoreBase
    {
        public DateTime CreateDate { get; set; }
    }

    public abstract class DbEntityWithDateBase : DbEntityBasicBase
    {
        [UpdatedAt]
        public DateTime? ModifiedDate { get; set; }
    }

    public abstract class DbEntityPartialBase : DbEntityWithDateBase
    {
        public bool IsActive { get; set; }
    }

    public abstract class DbEntityWithoutActiveBase : DbEntityWithDateBase
    {
        /// <summary>
        /// Employee Id will be mapped here
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Employee Id will be mapped here
        /// </summary>
        public int? ModifiedBy { get; set; }
    }

    public abstract class DbEntityFullBase : DbEntityWithoutActiveBase
    {
        public bool IsActive { get; set; }
    }

    public abstract class DbEntityBaseWithCompanyId : DbEntityFullBase
    {
        public int CompanyId { get; set; }
    }

    public abstract class DbEntityFullBaseWithCompanyId : DbEntityBaseWithCompanyId
    {
        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }

    public abstract class DbBasicDropdownEntityBase : DbEntityPartialBase
    {
        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }

    public abstract class DbEntityFullBaseForAccount : DbEntityFullBaseWithCompanyId
    {
        public int CurrencyId { get; set; }

        public int LedgerId { get; set; }
    }
}
