using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Infrastructure.Data.Enums;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Models.Ad
{
    public class AdPreviewViewModel
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        public string Engine { get; set; } = null!;

        [Required]
        public ConditionEnum Condition { get; set; }

        [Required]
        public EuroStandardEnum EuroStandard { get; set; }

        [Required]
        public FuelTypeEnum FuelType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public List<string> ImageUrls { get; set; } = new List<string>();

    }
}
