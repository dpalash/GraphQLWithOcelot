using System;
using Newtonsoft.Json;

namespace Framework.Core.Base.ModelEntity
{
    public abstract class ModelBasicBase : IModelEntityBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public abstract class ModelEntityBasicBase : ModelBasicBase
    {
        [JsonProperty("createDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Login Id will be mapped here
        /// </summary>
        [JsonProperty("createdBy")]
        public int CreatedBy { get; set; }

        [JsonProperty("createdByName")]
        public string CreatedByName { get; set; }
    }

    public abstract class ModelEntityDateBase : ModelEntityBasicBase
    {
        /// <summary>
        /// Login Id will be mapped here
        /// </summary>
        [JsonProperty("modifiedBy")]
        public int? ModifiedBy { get; set; }

        [JsonProperty("modifiedByName")]
        public string ModifiedByName { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }

    public abstract class ModelEntityBase : ModelEntityDateBase
    {
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    [Serializable]
    public abstract class ModelEntityBaseWithCompany : ModelEntityBase
    {
        [JsonProperty("companyId")]
        public int CompanyId { get; set; }
    }

    [Serializable]
    public abstract class DropDownModelEntityBasicBase : ModelBasicBase
    {
        private string _code;

        [JsonProperty("code")]
        public string Code
        {
            get => _code;
            set => _code = string.IsNullOrWhiteSpace(value) ? null : value;
        }

        private string _name;

        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? null : value;
        }
    }

    [Serializable]
    public abstract class ModelEntityBasicBaseWithCompany : ModelEntityBaseWithCompany
    {
        private string _code;

        [JsonProperty("code")]
        public string Code
        {
            get => _code;
            set => _code = string.IsNullOrWhiteSpace(value) ? null : value;
        }

        private string _name;

        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? null : value;
        }
    }

    [Serializable]
    public abstract class ModelEntityFullBaseForAccount : ModelEntityBasicBaseWithCompany
    {
        private int _ledgerId;

        [JsonProperty("currencyId")]
        public int CurrencyId { get; set; }

        [JsonProperty("ledgerId")]
        public int LedgerId
        {
            get => _ledgerId;
            set => _ledgerId = value;
        }
    }
}