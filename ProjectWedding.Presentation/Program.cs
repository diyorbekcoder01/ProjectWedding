using ProjectWedding.Data.Repositories;
using ProjectWedding.Domain.Entities;
using ProjectWedding.Domain.Enums;
using System;

namespace ProjectWedding
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Process started ... ");

            GenericRepository<Client> repo = new GenericRepository<Client>();
            GenericRepository<Restaurant> repoRestaurant = new GenericRepository<Restaurant>();
            GenericRepository<Gift> repoGift = new GenericRepository<Gift>();

            //Restaurant restaurant = new Restaurant()
            //{
            //    Id = 2,
            //    Name = "restaurant1",
            //    CreatedAt = DateTime.UtcNow,
            //    Quality = RestaurantQualitys.good,
            //    Products = new List<Product>()
            //    {
            //        new Product()
            //        {
            //            Id = 1,
            //            CreatedAt = DateTime.UtcNow,
            //            Name = "restaurant1product1n",
            //            Description = "restaurant1product1",
            //            Price = 100,
            //        },
            //        new Product()
            //        {
            //            Id = 2,
            //            CreatedAt = DateTime.UtcNow,
            //            Name = "restaurant1product2n",
            //            Description = "restaurant1product2",
            //            Price = 200,
            //        },
            //        new Product()
            //        {
            //            Id = 3,
            //            CreatedAt = DateTime.UtcNow,
            //            Name = "restaurant1product3n",
            //            Description = "restaurant1product3",
            //            Price = 300,
            //        }
            //    }
            //};
            //// restaurant created

            //Client client1 = new Client()
            //{
            //    Id = 1,
            //    Orders = new List<ClientOrder>
            //    {
            //        new ClientOrder
            //        {
            //            Id = 1,
            //            CreatedAt = DateTime.UtcNow,
            //            Restaurant = restaurant,
            //            Date = DateTime.UtcNow
            //        },
            //        new ClientOrder { },
            //        new ClientOrder { }
            //    },
            //    CreatedAt = DateTime.UtcNow,
            //    dateOfBirth = DateTime.UtcNow,
            //    email = "client1@gmail.com",
            //    firstName = "client1f",
            //    lastName = "client1l",
            //    Guests = new List<Guest>
            //    {
            //        // Client 1 -> Guest 1
            //        new Guest
            //        {
            //            Id = 1,
            //            CreatedAt = DateTime.UtcNow,
            //            lastName = "client1guest1l",
            //            firstName = "client1guest1f",
            //            dateOfBirth = DateTime.UtcNow,
            //            Email = "client1guest1gmail.com",
            //            Gifts = new List<Gift>
            //            {
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest1gift1",
            //                    Id = 1,
            //                    Name = "client1guest1gift1n",
            //                    Price = 100,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest1gift2",
            //                    Id = 2,
            //                    Name = "client1guest1gift2n",
            //                    Price = 200,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest1gift3",
            //                    Id = 3,
            //                    Name = "client1guest1gift3n",
            //                    Price = 300,
            //                }
            //            }
            //        },

            //        // Client 1 -> Guest 2
            //        new Guest
            //        {
            //            Id = 2,
            //            CreatedAt = DateTime.UtcNow,
            //            lastName = "client1guest2l",
            //            firstName = "client1guest2f",
            //            dateOfBirth = DateTime.UtcNow,
            //            Email = "client1guest2gmail.com",
            //            Gifts = new List<Gift>
            //            {
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest2gift1",
            //                    Id = 1,
            //                    Name = "client1guest2gift1n",
            //                    Price = 100,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest2gift2",
            //                    Id = 2,
            //                    Name = "client1guest2gift2n",
            //                    Price = 200,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest2gift3",
            //                    Id = 3,
            //                    Name = "client1guest2gift3n",
            //                    Price = 300,
            //                }
            //            }
            //        },

            //        // Client 1 -> Guest 3
            //        new Guest
            //        {
            //            Id = 3,
            //            CreatedAt = DateTime.UtcNow,
            //            lastName = "client1guest3l",
            //            firstName = "client1guest3f",
            //            dateOfBirth = DateTime.UtcNow,
            //            Email = "client1guest3gmail.com",
            //            Gifts = new List<Gift>
            //            {
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest3gift1",
            //                    Id = 1,
            //                    Name = "client1guest3gift1n",
            //                    Price = 100,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest3gift2",
            //                    Id = 2,
            //                    Name = "client1guest3gift2n",
            //                    Price = 200,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest3gift3",
            //                    Id = 3,
            //                    Name = "client1guest3gift3n",
            //                    Price = 300,
            //                }
            //            }
            //        }
            //    }

            //};

            //var res = await repo.CreateAsync(client1);

            //// created a client2
            //Client client2 = new Client()
            //{

            //    Orders = new List<ClientOrder>
            //    {
            //        new ClientOrder
            //        {
            //            Id = 1,
            //            CreatedAt = DateTime.UtcNow,
            //            Restaurant = restaurant,
            //            Date = DateTime.UtcNow
            //        },
            //        new ClientOrder { },
            //        new ClientOrder { }
            //    },
            //    CreatedAt = DateTime.UtcNow,
            //    dateOfBirth = DateTime.UtcNow,
            //    email = "client1@gmail.com",
            //    firstName = "client1f",
            //    lastName = "client1l",
            //    Guests = new List<Guest>
            //    {
            //        // Client 1 -> Guest 1
            //        new Guest
            //        {
            //            Id = 1,
            //            CreatedAt = DateTime.UtcNow,
            //            lastName = "client1guest1l",
            //            firstName = "client1guest1f",
            //            dateOfBirth = DateTime.UtcNow,
            //            Email = "client1guest1gmail.com",
            //            Gifts = new List<Gift>
            //            {
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest1gift1",
            //                    Id = 1,
            //                    Name = "client1guest1gift1n",
            //                    Price = 100,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest1gift2",
            //                    Id = 2,
            //                    Name = "client1guest1gift2n",
            //                    Price = 200,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest1gift3",
            //                    Id = 3,
            //                    Name = "client1guest1gift3n",
            //                    Price = 300,
            //                }
            //            }
            //        },

            //        // Client 1 -> Guest 2
            //        new Guest
            //        {
            //            Id = 2,
            //            CreatedAt = DateTime.UtcNow,
            //            lastName = "client1guest2l",
            //            firstName = "client1guest2f",
            //            dateOfBirth = DateTime.UtcNow,
            //            Email = "client1guest2gmail.com",
            //            Gifts = new List<Gift>
            //            {
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest2gift1",
            //                    Id = 1,
            //                    Name = "client1guest2gift1n",
            //                    Price = 100,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest2gift2",
            //                    Id = 2,
            //                    Name = "client1guest2gift2n",
            //                    Price = 200,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest2gift3",
            //                    Id = 3,
            //                    Name = "client1guest2gift3n",
            //                    Price = 300,
            //                }
            //            }
            //        },

            //        // Client 1 -> Guest 3
            //        new Guest
            //        {
            //            Id = 3,
            //            CreatedAt = DateTime.UtcNow,
            //            lastName = "client1guest3l",
            //            firstName = "client1guest3f",
            //            dateOfBirth = DateTime.UtcNow,
            //            Email = "client1guest3gmail.com",
            //            Gifts = new List<Gift>
            //            {
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest3gift1",
            //                    Id = 1,
            //                    Name = "client1guest3gift1n",
            //                    Price = 100,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest3gift2",
            //                    Id = 2,
            //                    Name = "client1guest3gift2n",
            //                    Price = 200,
            //                },
            //                new Gift
            //                {
            //                    CreatedAt = DateTime.UtcNow,
            //                    Description = "client1guest3gift3",
            //                    Id = 3,
            //                    Name = "client1guest3gift3n",
            //                    Price = 300,
            //                }
            //            }
            //        }
            //    }

            //};

            //var res2 = await repo.CreateAsync(client2);
            //bool resDelete = await repo.DeleteAsync(1);
            //Console.WriteLine(resDelete);
            //Client client3 = new Client();
            //var res3 = await repo.CreateAsync(client3);
            //var resRestaurantCreated = await repoRestaurant.CreateAsync(restaurant);
            //var resRestaurantDeleted = await repoRestaurant.DeleteAsync(1);

            //Restaurant restaurant = new Restaurant();
            //var res = await repoRestaurant.CreateAsync(restaurant);
            //Console.WriteLine(res);

            //Gift gift = new Gift()
            //{
            //    Id = 1,
            //    Description= "Gift1",
            //    Name = "Gift1n",
            //    Price = 100
            //};
            //var resGiftCreated = await repoGift.CreateAsync(gift);

            Console.WriteLine("\nSystem failure\n");
        }
    }
}