﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TubeStore.DataLayer;

namespace TubeStore.Migrations
{
    [DbContext(typeof(TubeStoreDbContext))]
    [Migration("20200303165452_chat6")]
    partial class chat6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TubeStore.Models.Carousel", b =>
                {
                    b.Property<int>("CarouselId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarouselId");

                    b.ToTable("Carousels");

                    b.HasData(
                        new
                        {
                            CarouselId = 1,
                            Description = "Premium selected",
                            ImageUrl = "/Images/Carousel/carousel_01.jpg",
                            Status = true,
                            Title = "ECC82"
                        },
                        new
                        {
                            CarouselId = 2,
                            Description = "Platinum matched quad",
                            ImageUrl = "/Images/Carousel/carousel_02.jpg",
                            Status = true,
                            Title = "6P14P"
                        },
                        new
                        {
                            CarouselId = 3,
                            Description = "Tested pre-amp set",
                            ImageUrl = "/Images/Carousel/carousel_03.jpg",
                            Status = true,
                            Title = "6N6P"
                        });
                });

            modelBuilder.Entity("TubeStore.Models.Cart.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CouponName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouponStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CouponValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CouponId");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            CouponName = "ten",
                            CouponStatus = "Active",
                            CouponValue = 0.1m
                        },
                        new
                        {
                            CouponId = 2,
                            CouponName = "fifteen",
                            CouponStatus = "Expired",
                            CouponValue = 0.15m
                        },
                        new
                        {
                            CouponId = 3,
                            CouponName = "five",
                            CouponStatus = "Active",
                            CouponValue = 0.05m
                        });
                });

            modelBuilder.Entity("TubeStore.Models.Cart.ShippingAddress", b =>
                {
                    b.Property<int>("ShippingAdressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("ShippingAdressId");

                    b.ToTable("ShippingAddresses");
                });

            modelBuilder.Entity("TubeStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Pre Triodes"
                        });
                });

            modelBuilder.Entity("TubeStore.Models.Chat.ChatGroup", b =>
                {
                    b.Property<long>("ChatGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChatGroupId");

                    b.ToTable("ChatGroups");
                });

            modelBuilder.Entity("TubeStore.Models.Chat.ChatMessage", b =>
                {
                    b.Property<long>("ChatMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ChatGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MessageDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChatMessageId");

                    b.HasIndex("ChatGroupId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("TubeStore.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TubeStore.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CouponId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShippingAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CouponId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("TubeStore.Models.InvoiceInfo", b =>
                {
                    b.Property<int>("InvoiceInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TubeId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceInfoId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("TubeId");

                    b.ToTable("InvoiceInfos");
                });

            modelBuilder.Entity("TubeStore.Models.Notification.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NotificationText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("TubeStore.Models.Notification.NotificationUser", b =>
                {
                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.HasKey("NotificationId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("NotificationUsers");
                });

            modelBuilder.Entity("TubeStore.Models.Tube", b =>
                {
                    b.Property<int>("TubeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FullDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNewArrival")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTubeOfTheWeek")
                        .HasColumnType("bit");

                    b.Property<bool>("MatchedPair")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TubeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tubes");

                    b.HasData(
                        new
                        {
                            TubeId = 1,
                            Brand = "NEVZ",
                            CategoryId = 1,
                            Date = "10.1963",
                            Discount = 0.05m,
                            FullDescription = "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.",
                            ImageThumbnailUrl = "/Images/Pre Triodes/6N1P/20160808_6N1Pnevz_small.jpg",
                            ImageUrl = "/Images/Pre Triodes/6N1P/20160808_6N1Pnevz.jpg",
                            IsNewArrival = false,
                            IsTubeOfTheWeek = false,
                            MatchedPair = true,
                            Price = 12.00m,
                            Quantity = 62,
                            ShortDescription = "NOS, Gray plates, gold grids, mica",
                            Type = "6N1P"
                        },
                        new
                        {
                            TubeId = 2,
                            Brand = "NEVZ",
                            CategoryId = 1,
                            Date = "01.1967",
                            Discount = 0m,
                            FullDescription = "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.",
                            ImageThumbnailUrl = "/Images/Pre Triodes/6N1P/20170201_6N1Pboxplates_small.jpg",
                            ImageUrl = "/Images/Pre Triodes/6N1P/20170201_6N1Pboxplates.jpg",
                            IsNewArrival = false,
                            IsTubeOfTheWeek = true,
                            MatchedPair = true,
                            Price = 115.00m,
                            Quantity = 12,
                            ShortDescription = "NOS, box plates",
                            Type = "6N1P"
                        },
                        new
                        {
                            TubeId = 3,
                            Brand = "Foton",
                            CategoryId = 1,
                            Date = "1960s",
                            Discount = 0m,
                            FullDescription = "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.",
                            ImageThumbnailUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pfoton_small.jpg",
                            ImageUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pfoton.jpg",
                            IsNewArrival = false,
                            IsTubeOfTheWeek = false,
                            MatchedPair = true,
                            Price = 39.99m,
                            Quantity = 30,
                            ShortDescription = "square getter, millitary grade",
                            Type = "6N6P"
                        },
                        new
                        {
                            TubeId = 4,
                            Brand = "NEVZ",
                            CategoryId = 1,
                            Date = "08.1974",
                            Discount = 0m,
                            FullDescription = "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.",
                            ImageThumbnailUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pnevz_small.jpg",
                            ImageUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pnevz.jpg",
                            IsNewArrival = true,
                            IsTubeOfTheWeek = false,
                            MatchedPair = true,
                            Price = 89.99m,
                            Quantity = 10,
                            ShortDescription = "gold pin & grid",
                            Type = "6N6P"
                        },
                        new
                        {
                            TubeId = 5,
                            Brand = "Tungsram",
                            CategoryId = 1,
                            Date = "1970s",
                            Discount = 0m,
                            FullDescription = "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ",
                            ImageThumbnailUrl = "/Images/Pre Triodes/ECC82/20171220_ECC82tungsram_small.jpg",
                            ImageUrl = "/Images/Pre Triodes/ECC82/20171220_ECC82tungsram.jpg",
                            IsNewArrival = true,
                            IsTubeOfTheWeek = false,
                            MatchedPair = false,
                            Price = 49.99m,
                            Quantity = 11,
                            ShortDescription = "Made in hungary",
                            Type = "ECC82"
                        },
                        new
                        {
                            TubeId = 6,
                            Brand = "Mullard",
                            CategoryId = 1,
                            Date = "02.1961",
                            Discount = 0m,
                            FullDescription = "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ",
                            ImageThumbnailUrl = "/Images/Pre Triodes/ECC82/20171212_ECC82mullard_small.jpg",
                            ImageUrl = "/Images/Pre Triodes/ECC82/20171212_ECC82mullard.jpg",
                            IsNewArrival = true,
                            IsTubeOfTheWeek = false,
                            MatchedPair = false,
                            Price = 299.99m,
                            Quantity = 3,
                            ShortDescription = "Made in Great Britain",
                            Type = "ECC82"
                        });
                });

            modelBuilder.Entity("TubeStore.Models.Watchlist", b =>
                {
                    b.Property<int>("WatchlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("TubeId")
                        .HasColumnType("int");

                    b.HasKey("WatchlistId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TubeId");

                    b.ToTable("Watchlists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TubeStore.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TubeStore.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubeStore.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TubeStore.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TubeStore.Models.Category", b =>
                {
                    b.HasOne("TubeStore.Models.Category", "Parent")
                        .WithMany("Parents")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TubeStore.Models.Chat.ChatMessage", b =>
                {
                    b.HasOne("TubeStore.Models.Chat.ChatGroup", null)
                        .WithMany("ChatMessages")
                        .HasForeignKey("ChatGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubeStore.Models.Customer", null)
                        .WithMany("ChatMessages")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("TubeStore.Models.Invoice", b =>
                {
                    b.HasOne("TubeStore.Models.Cart.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId");

                    b.HasOne("TubeStore.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId");

                    b.HasOne("TubeStore.Models.Cart.ShippingAddress", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TubeStore.Models.InvoiceInfo", b =>
                {
                    b.HasOne("TubeStore.Models.Invoice", "Invoice")
                        .WithMany("InvoicesInfo")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("TubeStore.Models.Tube", "Tube")
                        .WithMany()
                        .HasForeignKey("TubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TubeStore.Models.Notification.NotificationUser", b =>
                {
                    b.HasOne("TubeStore.Models.Customer", "Customer")
                        .WithMany("NotificationUsers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubeStore.Models.Notification.Notification", "Notification")
                        .WithMany("NotificationUsers")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TubeStore.Models.Tube", b =>
                {
                    b.HasOne("TubeStore.Models.Category", "Category")
                        .WithMany("Tubes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TubeStore.Models.Watchlist", b =>
                {
                    b.HasOne("TubeStore.Models.Customer", "Customer")
                        .WithMany("Watchlists")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubeStore.Models.Tube", "Tube")
                        .WithMany("Watchlists")
                        .HasForeignKey("TubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
