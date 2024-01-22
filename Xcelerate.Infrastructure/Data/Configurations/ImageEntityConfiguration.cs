using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Infrastructure.Data.Enums;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasOne(c => c.Car)
                .WithMany(c => c.Images)
                .OnDelete(DeleteBehavior.NoAction);


            ICollection<Image> imagesCollection = CreateImages();
            builder.HasData(CreateImages());
        }

        private ICollection<Image> CreateImages()
        {
            List<Image> imageCollections = new List<Image>();

            // Car 1
            imageCollections!.Add(new Image() { CarId = 1, ImageId = 1, ImageUrl = "2020_toyota_camry_trd_1.jpg" });
            imageCollections!.Add(new Image() { CarId = 1, ImageId = 2, ImageUrl = "2020_toyota_camry_trd_3.jpg" });
            imageCollections!.Add(new Image() { CarId = 1, ImageId = 3, ImageUrl = "2020_toyota_camry_trd_5.jpg" });
            imageCollections!.Add(new Image() { CarId = 1, ImageId = 4, ImageUrl = "2020_toyota_camry_trd_6.jpg" });
            imageCollections!.Add(new Image() { CarId = 1, ImageId = 5, ImageUrl = "2020_toyota_camry_trd_7.jpg" });
            imageCollections!.Add(new Image() { CarId = 1, ImageId = 6, ImageUrl = "2020_toyota_camry_trd_11.jpg" });

            // Car 2
            imageCollections!.Add(new Image() { CarId = 2, ImageId = 7, ImageUrl = "2021_honda_civic_type_r_limited_edition.jpg" });
            imageCollections!.Add(new Image() { CarId = 2, ImageId = 8, ImageUrl = "2021_honda_civic_type_r_limited_edition_2.jpg" });
            imageCollections!.Add(new Image() { CarId = 2, ImageId = 9, ImageUrl = "2021_honda_civic_type_r_limited_edition_3.jpg" });
            imageCollections!.Add(new Image() { CarId = 2, ImageId = 10, ImageUrl = "2021_honda_civic_type_r_limited_edition_4.jpg" });
            imageCollections!.Add(new Image() { CarId = 2, ImageId = 11, ImageUrl = "2021_honda_civic_type_r_limited_edition_5.jpg" });
            imageCollections!.Add(new Image() { CarId = 2, ImageId = 12, ImageUrl = "2021_honda_civic_type_r_limited_edition_11.jpg" });

            // Car 3
            imageCollections!.Add(new Image() { CarId = 3, ImageId = 13, ImageUrl = "2020_ford_mustang_shelby_gt350r.jpg" });
            imageCollections!.Add(new Image() { CarId = 3, ImageId = 14, ImageUrl = "2020_ford_mustang_shelby_gt350r_1.jpg" });
            imageCollections!.Add(new Image() { CarId = 3, ImageId = 15, ImageUrl = "2020_ford_mustang_shelby_gt350r_2.jpg" });
            imageCollections!.Add(new Image() { CarId = 3, ImageId = 16, ImageUrl = "2020_ford_mustang_shelby_gt350r_3.jpg" });
            imageCollections!.Add(new Image() { CarId = 3, ImageId = 17, ImageUrl = "2020_ford_mustang_shelby_gt350r_5.jpg" });
            imageCollections!.Add(new Image() { CarId = 3, ImageId = 18, ImageUrl = "2020_ford_mustang_shelby_gt350r_7.jpg" });


            // Car 4
            imageCollections!.Add(new Image() { CarId = 4, ImageId = 19, ImageUrl = "2020_volkswagen_golf.jpg" });
            imageCollections!.Add(new Image() { CarId = 4, ImageId = 20, ImageUrl = "2020_volkswagen_golf_47.jpg" });
            imageCollections!.Add(new Image() { CarId = 4, ImageId = 21, ImageUrl = "2020_volkswagen_golf_48.jpg" });
            imageCollections!.Add(new Image() { CarId = 4, ImageId = 22, ImageUrl = "2020_volkswagen_golf_50.jpg" });
            imageCollections!.Add(new Image() { CarId = 4, ImageId = 23, ImageUrl = "2020_volkswagen_golf_51.jpg" });
            imageCollections!.Add(new Image() { CarId = 4, ImageId = 24, ImageUrl = "2020_volkswagen_golf_23.jpg" });

            // Car 5
            imageCollections!.Add(new Image() { CarId = 5, ImageId = 25, ImageUrl = "2022-Mercedes-Benz-C-Class.jpg" });
            imageCollections!.Add(new Image() { CarId = 5, ImageId = 26, ImageUrl = "2022-Mercedes-Benz-C-Class 2.jpg" });
            imageCollections!.Add(new Image() { CarId = 5, ImageId = 27, ImageUrl = "2022-Mercedes-Benz-C-Class 3.jpg" });
            imageCollections!.Add(new Image() { CarId = 5, ImageId = 28, ImageUrl = "2022-Mercedes-Benz-C-Class 4.jpg" });
            imageCollections!.Add(new Image() { CarId = 5, ImageId = 29, ImageUrl = "2022-Mercedes-Benz-C-Class 5.jpg" });
            imageCollections!.Add(new Image() { CarId = 5, ImageId = 30, ImageUrl = "2022-Mercedes-Benz-C-Class 6.jpg" });

            // Car 6
            imageCollections!.Add(new Image() { CarId = 6, ImageId = 31, ImageUrl = "2021_audi_s3_6.jpg" });
            imageCollections!.Add(new Image() { CarId = 6, ImageId = 32, ImageUrl = "2021_audi_s3_5.jpg" });
            imageCollections!.Add(new Image() { CarId = 6, ImageId = 33, ImageUrl = "2021_audi_s3_10.jpg" });
            imageCollections!.Add(new Image() { CarId = 6, ImageId = 34, ImageUrl = "2021_audi_s3_11.jpg" });
            imageCollections!.Add(new Image() { CarId = 6, ImageId = 35, ImageUrl = "2021_audi_s3_12.jpg" });
            imageCollections!.Add(new Image() { CarId = 6, ImageId = 36, ImageUrl = "2021_audi_s3_15.jpg" });

            // Car 7
            imageCollections!.Add(new Image() { CarId = 7, ImageId = 37, ImageUrl = "2022_infiniti_qx80_1.jpg" });
            imageCollections!.Add(new Image() { CarId = 7, ImageId = 38, ImageUrl = "2022_infiniti_qx80_11.jpg" });
            imageCollections!.Add(new Image() { CarId = 7, ImageId = 39, ImageUrl = "2022_infiniti_qx80_12.jpg" });
            imageCollections!.Add(new Image() { CarId = 7, ImageId = 40, ImageUrl = "2022_infiniti_qx80_13.jpg" });
            imageCollections!.Add(new Image() { CarId = 7, ImageId = 41, ImageUrl = "2022_infiniti_qx80_17.jpg" });
            imageCollections!.Add(new Image() { CarId = 7, ImageId = 42, ImageUrl = "2022_infiniti_qx80_20.jpg" });

            // Car 8
            imageCollections!.Add(new Image() { CarId = 8, ImageId = 43, ImageUrl = "2021_hyundai_elantra_3.jpg" });
            imageCollections!.Add(new Image() { CarId = 8, ImageId = 44, ImageUrl = "2021_hyundai_elantra_4.jpg" });
            imageCollections!.Add(new Image() { CarId = 8, ImageId = 45, ImageUrl = "2021_hyundai_elantra_5.jpg" });
            imageCollections!.Add(new Image() { CarId = 8, ImageId = 46, ImageUrl = "2021_hyundai_elantra_6.jpg" });
            imageCollections!.Add(new Image() { CarId = 8, ImageId = 47, ImageUrl = "2021_hyundai_elantra_7.jpg" });
            imageCollections!.Add(new Image() { CarId = 8, ImageId = 48, ImageUrl = "2021_hyundai_elantra_16.jpg" });

            // Car 9
            imageCollections!.Add(new Image() { CarId = 9, ImageId = 49, ImageUrl = "2022_bmw_m3_competition_xdrive.jpg" });
            imageCollections!.Add(new Image() { CarId = 9, ImageId = 50, ImageUrl = "2022_bmw_m3_competition_xdrive_23.jpg" });
            imageCollections!.Add(new Image() { CarId = 9, ImageId = 51, ImageUrl = "2022_bmw_m3_competition_xdrive_25.jpg" });
            imageCollections!.Add(new Image() { CarId = 9, ImageId = 52, ImageUrl = "2022_bmw_m3_competition_xdrive_27.jpg" });
            imageCollections!.Add(new Image() { CarId = 9, ImageId = 53, ImageUrl = "2022_bmw_m3_competition_xdrive_28.jpg" });
            imageCollections!.Add(new Image() { CarId = 9, ImageId = 54, ImageUrl = "2022_bmw_m3_competition_xdrive_29.jpg" });

            // Car 10
            imageCollections!.Add(new Image() { CarId = 10, ImageId = 55, ImageUrl = "2021_nissan_rogue_1.jpg" });
            imageCollections!.Add(new Image() { CarId = 10, ImageId = 56, ImageUrl = "2021_nissan_rogue_3.jpg" });
            imageCollections!.Add(new Image() { CarId = 10, ImageId = 57, ImageUrl = "2021_nissan_rogue_5.jpg" });
            imageCollections!.Add(new Image() { CarId = 10, ImageId = 58, ImageUrl = "2021_nissan_rogue_6.jpg" });
            imageCollections!.Add(new Image() { CarId = 10, ImageId = 59, ImageUrl = "2021_nissan_rogue_12.jpg" });
            imageCollections!.Add(new Image() { CarId = 10, ImageId = 60, ImageUrl = "2021_nissan_rogue_18.jpg" });

            return imageCollections;
        }
    }
}
