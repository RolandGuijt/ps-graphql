using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarvedRock.Api.data.migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[,]
                {
                    { 1, "Use these sturdy shoes to pass any mountain range with ease.", new DateTimeOffset(new DateTime(2023, 7, 20, 15, 11, 9, 418, DateTimeKind.Unspecified).AddTicks(3716), new TimeSpan(0, 2, 0, 0, 0)), "Mountain Walkers", "shutterstock_66842440.jpg", 219.5m, 4, 12, 0 },
                    { 2, "For your everyday marches in the army.", new DateTimeOffset(new DateTime(2023, 7, 20, 15, 11, 9, 418, DateTimeKind.Unspecified).AddTicks(3831), new TimeSpan(0, 2, 0, 0, 0)), "Army Slippers", "shutterstock_222721876.jpg", 125.9m, 3, 56, 0 },
                    { 3, "This backpack can survive any tornado.", new DateTimeOffset(new DateTime(2023, 7, 20, 15, 11, 9, 418, DateTimeKind.Unspecified).AddTicks(3860), new TimeSpan(0, 2, 0, 0, 0)), "Backpack Deluxe", "shutterstock_6170527.jpg", 199.99m, 5, 66, 1 },
                    { 4, "Anything you need to climb the mount Everest.", new DateTimeOffset(new DateTime(2023, 7, 20, 15, 11, 9, 418, DateTimeKind.Unspecified).AddTicks(3904), new TimeSpan(0, 2, 0, 0, 0)), "Climbing Kit", "shutterstock_48040747.jpg", 299.5m, 5, 3, 1 },
                    { 5, "Simply the fastest kayak on earth and beyond for 2 persons.", new DateTimeOffset(new DateTime(2023, 7, 20, 15, 11, 9, 418, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 2, 0, 0, 0)), "Blue Racer", "shutterstock_441989509.jpg", 350m, 5, 8, 2 },
                    { 6, "One person kayak with hyper boost button.", new DateTimeOffset(new DateTime(2023, 7, 20, 15, 11, 9, 418, DateTimeKind.Unspecified).AddTicks(3952), new TimeSpan(0, 2, 0, 0, 0)), "Orange Demon", "shutterstock_495259978.jpg", 450m, 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[,]
                {
                    { 1, 1, "First released almost 30 years ago, the Titan 26078 is a classic work boot. It’s also one of Timberland’s all time best sellers.", "Crossed the Himalayas" },
                    { 2, 1, "One of the most comfortable hiking boots available, each pair comes complete with the Power Fit Comfort System, designed to offer maximum support at key areas of your feet.", "Comfortable" },
                    { 3, 2, "They have absolutely no break in period and can literally be worn to work the day that you get them.", "Indestructible" },
                    { 4, 2, "The safety toe is made from an aluminium alloy which offers all the protection of steel but half the weight. The soles are also oil, abrasion and slip resistant.", "Safety toe" },
                    { 5, 3, "The Better Backpack is made from 100% recycled plastic but looks and feels like canvas. We were sent the grey bag with the tan leather accents and silver zippers. I’ve personally always liked tan leather paired with the color grey and appreciate the feel of the leather pull tabs and handles at the top of the bag. Additionally the inside is navy blue with a diagonal stitch pattern which gives it an air of sophistication.", "Feels like canvas" },
                    { 6, 5, "So this is my 1st ever kayak and my 1st experience paddling a kayak. I struggled with whether I should spend more money to buy a \"Fishing\" kayak, or even a \"higher end\" kayak because my fear was paddling around a bathtub on the lake. I have to say, I love this kayak for me. It doesn't have a lot of the bells and whistles that some of the pricier kayaks have but, I'm not disappointed.\r\n\r\nIt's pretty bare bones aside from some dry storage areas and some bungees. It does have a bungee to hold your paddle on the side. I feel it paddles very easy. It goes exactly where I want it to, I didn't struggle to keep it on course. A stiff wind can knock you off track but it was very sturdy and I feel like it would take a lot to tip it over. I stayed fairly dry aside from the dripping off the paddle but its a sit on top so thats to be expected.", "So this is my 1st ever..." },
                    { 7, 5, "I am a fit 5'7 woman 140lbs and I take my 30# dog along with no troubles. I have fished with it by using a bucket strapped in the back with my bungee cords. It holds my rods and small tackle tray, bug spray etc so I can get to it all easily. I can even get it up on the roof of my jeep alone. ", "Great for all genders" },
                    { 8, 5, "Very happy with my purchase and I recommend this to anyone who doesn't want to spend over 600$ on a kayak but also doesn't want a cheap ole hunk of plastic. ", "Happy" },
                    { 9, 6, "Hobie took the paddle out of the hands of the masses, and changed kayak fishing forever. Ive heavily fished the 'Revo' since 2011 and feel its about perfect for my use. As a serious cyclist its a natural fit, and it can cover huge distances. The torque the Mirage drive generates in rough conditions is often overlooked. I feel it could easily pull any propeller driven kayak backwards in a tug-o-war. I recently weighed my bare hull at 69#s, and that's not too shabby for ANY pedal yak. I still fish from paddle yaks, but I spend more time with the rods in my hands when on the Revo.", "Hobie took the paddle out" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
