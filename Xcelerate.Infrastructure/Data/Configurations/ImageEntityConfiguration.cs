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

			// Car 11
			imageCollections!.Add(new Image() { CarId = 11, ImageId = 61, ImageUrl = "1969 El Camino SS-Side-Profile.jpg" });
			imageCollections!.Add(new Image() { CarId = 11, ImageId = 62, ImageUrl = "1969 El Camino SS_Front.jpg" });
			imageCollections!.Add(new Image() { CarId = 11, ImageId = 63, ImageUrl = "1969 El Camino SS-Trunk.jpg" });
			imageCollections!.Add(new Image() { CarId = 11, ImageId = 64, ImageUrl = "1969 El Camino SS-Side-Door.jpg" });
			imageCollections!.Add(new Image() { CarId = 11, ImageId = 65, ImageUrl = "1969 El Camino SS-Chassis.jpg" });
			imageCollections!.Add(new Image() { CarId = 11, ImageId = 66, ImageUrl = "1969 El Camino SS_Engine.jpg" });

			// Car 12
			imageCollections!.Add(new Image() { CarId = 12, ImageId = 67, ImageUrl = "2013 Chevrolet Tahoe-Side-Profile.jpg" });
			imageCollections!.Add(new Image() { CarId = 12, ImageId = 68, ImageUrl = "2013 Chevrolet Tahoe-Front.jpg" });
			imageCollections!.Add(new Image() { CarId = 12, ImageId = 69, ImageUrl = "2013 Chevrolet Tahoe-Side.jpg" });
			imageCollections!.Add(new Image() { CarId = 12, ImageId = 70, ImageUrl = "2013 Chevrolet Tahoe-Back.jpg" });
			imageCollections!.Add(new Image() { CarId = 12, ImageId = 71, ImageUrl = "2013 Chevrolet Tahoe-Engine.jpg" });
			imageCollections!.Add(new Image() { CarId = 12, ImageId = 72, ImageUrl = "2013 Chevrolet Tahoe-Interiour.jpg" });

			// Car 13
			imageCollections!.Add(new Image() { CarId = 13, ImageId = 73, ImageUrl = "2000 Ford F-350 Super Duty-Side-Profile.jpg" });
			imageCollections!.Add(new Image() { CarId = 13, ImageId = 74, ImageUrl = "2000 Ford F-350 Super Duty-Front.jpg" });
			imageCollections!.Add(new Image() { CarId = 13, ImageId = 75, ImageUrl = "2000 Ford F-350 Super Duty-Side-Profile-2.jpg" });
			imageCollections!.Add(new Image() { CarId = 13, ImageId = 76, ImageUrl = "2000 Ford F-350 Super Duty-Back.jpg" });
			imageCollections!.Add(new Image() { CarId = 13, ImageId = 77, ImageUrl = "2000 Ford F-350 Super Duty-Engine.jpg" });
			imageCollections!.Add(new Image() { CarId = 13, ImageId = 78, ImageUrl = "2000 Ford F-350 Super Duty-Interiour.jpg" });

			// Car 14
			imageCollections!.Add(new Image() { CarId = 14, ImageId = 79, ImageUrl = "2013_renault_clio_32.jpg" });
			imageCollections!.Add(new Image() { CarId = 14, ImageId = 80, ImageUrl = "2013_renault_clio_33.jpg" });
			imageCollections!.Add(new Image() { CarId = 14, ImageId = 81, ImageUrl = "2013_renault_clio_34.jpg" });
			imageCollections!.Add(new Image() { CarId = 14, ImageId = 82, ImageUrl = "2013_renault_clio_35.jpg" });
			imageCollections!.Add(new Image() { CarId = 14, ImageId = 83, ImageUrl = "2013_renault_clio_36.jpg" });
			imageCollections!.Add(new Image() { CarId = 14, ImageId = 84, ImageUrl = "2013_renault_clio_47.jpg" });

			// Car 15
			imageCollections!.Add(new Image() { CarId = 15, ImageId = 85, ImageUrl = "1998 Mercedes-Benz W140 S-class S600L-Side-Profile.jpg" });
			imageCollections!.Add(new Image() { CarId = 15, ImageId = 86, ImageUrl = "1998 Mercedes-Benz W140 S-class S600L-Back.jpg" });
			imageCollections!.Add(new Image() { CarId = 15, ImageId = 87, ImageUrl = "1998 Mercedes-Benz W140 S-class S600L-Front.jpg" });
			imageCollections!.Add(new Image() { CarId = 15, ImageId = 88, ImageUrl = "1998 Mercedes-Benz W140 S-class S600L-Engine.jpg" });
			imageCollections!.Add(new Image() { CarId = 15, ImageId = 89, ImageUrl = "1998 Mercedes-Benz W140 S-class S600L-Dashboard.jpg" });
			imageCollections!.Add(new Image() { CarId = 15, ImageId = 90, ImageUrl = "1998 Mercedes-Benz W140 S-class S600L-Interiour.jpg" });

			imageCollections!.Add(new Image() { CarId = 16, ImageId = 91, ImageUrl = "Acura 2005 RSX Type-S.jpg" });
			imageCollections!.Add(new Image() { CarId = 16, ImageId = 92, ImageUrl = "Acura 2005 RSX Type-S-Side.jpg" });
			imageCollections!.Add(new Image() { CarId = 16, ImageId = 93, ImageUrl = "Acura 2005 RSX Type-S-Back.jpg" });
			imageCollections!.Add(new Image() { CarId = 16, ImageId = 94, ImageUrl = "Acura 2005 RSX Type-S-Front.jpg" });
			imageCollections!.Add(new Image() { CarId = 16, ImageId = 95, ImageUrl = "Acura 2005 RSX Type-S-Interiour.jpg" });
			imageCollections!.Add(new Image() { CarId = 16, ImageId = 96, ImageUrl = "Acura 2005 RSX Type-S-Engine.jpg" });

			imageCollections!.Add(new Image() { CarId = 17, ImageId = 97, ImageUrl = "Acura 2005 NSX-Side-Profile.jpg" });
			imageCollections!.Add(new Image() { CarId = 17, ImageId = 98, ImageUrl = "Acura 2005 NSX.jpg" });
			imageCollections!.Add(new Image() { CarId = 17, ImageId = 99, ImageUrl = "Acura 2005 NSX-Back.jpg" });
			imageCollections!.Add(new Image() { CarId = 17, ImageId = 100, ImageUrl = "Acura 2005 NSX-Engine.jpg" });
			imageCollections!.Add(new Image() { CarId = 17, ImageId = 101, ImageUrl = "Acura 2005 NSX-Interiour.jpg" });
			imageCollections!.Add(new Image() { CarId = 17, ImageId = 102, ImageUrl = "Acura 2005 NSX-Dashboard.jpg" });

			imageCollections!.Add(new Image() { CarId = 18, ImageId = 103, ImageUrl = "Saab 2001 9-3 Aero.jpg" });
			imageCollections!.Add(new Image() { CarId = 18, ImageId = 104, ImageUrl = "Saab 2001 9-3 Aero-Side.jpg" });
			imageCollections!.Add(new Image() { CarId = 18, ImageId = 105, ImageUrl = "Saab 2001 9-3 Aero-Other-Side.jpg" });
			imageCollections!.Add(new Image() { CarId = 18, ImageId = 106, ImageUrl = "Saab 2001 9-3 Aero-Front.jpg" });
			imageCollections!.Add(new Image() { CarId = 18, ImageId = 107, ImageUrl = "Saab 2001 9-3 Aero-Wheel.jpg" });
			imageCollections!.Add(new Image() { CarId = 18, ImageId = 108, ImageUrl = "Saab 2001 9-3 Aero-Emblem.jpg" });

			imageCollections!.Add(new Image() { CarId = 19, ImageId = 109, ImageUrl = "Saab 2006 93 SportCombi.jpg" });
			imageCollections!.Add(new Image() { CarId = 19, ImageId = 110, ImageUrl = "Saab 2006 93 SportCombi-Back.jpg" });
			imageCollections!.Add(new Image() { CarId = 19, ImageId = 111, ImageUrl = "Saab 2006 93 SportCombi-Trunk.jpg" });
			imageCollections!.Add(new Image() { CarId = 19, ImageId = 112, ImageUrl = "Saab 2006 93 SportCombi-Side.jpg" });
			imageCollections!.Add(new Image() { CarId = 19, ImageId = 113, ImageUrl = "Saab 2006 93 SportCombi-Dashboard.jpg" });
			imageCollections!.Add(new Image() { CarId = 19, ImageId = 114, ImageUrl = "Saab 2006 93 SportCombi-Driving.jpg" });

			imageCollections!.Add(new Image() { CarId = 20, ImageId = 115, ImageUrl = "Renault Megane II CoupeCabriolet.jpg" });
			imageCollections!.Add(new Image() { CarId = 20, ImageId = 116, ImageUrl = "Renault Megane II CoupeCabriolet-Side.jpg" });
			imageCollections!.Add(new Image() { CarId = 20, ImageId = 117, ImageUrl = "Renault Megane II CoupeCabriolet-Side-Top.jpg" });
			imageCollections!.Add(new Image() { CarId = 20, ImageId = 118, ImageUrl = "Renault Megane II CoupeCabriolet-Front.jpg" });
			imageCollections!.Add(new Image() { CarId = 20, ImageId = 119, ImageUrl = "Renault Megane II CoupeCabriolet-Trunk.jpg" });
			imageCollections!.Add(new Image() { CarId = 20, ImageId = 120, ImageUrl = "Renault Megane II CoupeCabriolet-Interiour.jpg" });

			return imageCollections;
		}
	}
}
