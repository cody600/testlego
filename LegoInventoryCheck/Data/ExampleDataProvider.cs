using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LegoInventoryCheck.Data.Interfaces;

namespace LegoInventoryCheck.Data
{
    //Data 

    public class ExampleDataProvider : IExampleDataProvider
    {
        public Catalogue GetLegoCatalogue()
        {
            return new Catalogue
            {
                Sets = new List<ISet>(
                [
                    new Set {
                            Name = "1",
                            Items =
                                    [
                                        new Item {
                                            Part = new Part { Number = 3023, Color = "Blue" },
                                            Count = 4 },
                                        new Item {
                                            Part = new Part { Number = 4286, Color = "Red" },
                                            Count = 2 },
                                        new Item {
                                            Part = new Part { Number = 4286, Color = "White" },
                                            Count = 1 }
                                    ]
                    },
                    new Set {
                            Name = "2",
                            Items =
                                    [  new Item {
                                            Part = new Part { Number = 3024, Color = "Red" },
                                            Count = 3 },
                                        new Item {
                                            Part = new Part { Number = 4287, Color = "Red" },
                                            Count = 2 },
                                        new Item {
                                            Part = new Part { Number = 4289, Color = "White" },
                                            Count = 1 }
                                    ]
                    },
                      new Set {
                            Name = "tropical-island",
                            Items =
                                    [  new Item {
                                            Part = new Part { Number = 3024, Color = "Blue" },
                                            Count = 5 },
                                        new Item {
                                            Part = new Part { Number = 4287, Color = "Red" },
                                            Count = 2 },
                                        new Item {
                                            Part = new Part { Number = 4289, Color = "White" },
                                            Count = 1 }
                                    ]
                    }
                ]
                )
            };
        }

        public List<IUser> GetUsers()
        {
            return new List<IUser>(
                 [ new User {
                    Name ="brickfan35",
                    Items =[
                            new Item {
                                Part = new Part { Number = 3023, Color = "Blue" },
                                Count = 4 },
                            new Item {
                                Part = new Part { Number = 4286, Color = "Red" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4286, Color = "White" },
                                Count = 1 },
                            new Item {
                                Part = new Part { Number = 4289, Color = "White" },
                                Count = 1 }
                    ]
                },
                new User {
                    Name ="landscape-artist",
                    Items =[
                            new Item {
                                Part = new Part { Number = 3023, Color = "Blue" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4286, Color = "Red" },
                                Count = 1 },
                            new Item {
                                Part = new Part { Number = 4286, Color = "White" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4289, Color = "White" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 3024, Color = "Blue" },
                                Count = 1 },
                            new Item {
                                Part = new Part { Number = 4287, Color = "Red" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4289, Color = "White" },
                                Count = 1 }
                    ]
                },
                 new User {
                    Name ="lndscape-artist-helper",
                    Items =[
                            new Item {
                                Part = new Part { Number = 3023, Color = "Blue" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4286, Color = "Red" },
                                Count = 1 },
                            new Item {
                                Part = new Part { Number = 4286, Color = "White" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4289, Color = "White" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 3024, Color = "Blue" },
                                Count = 5 },
                            new Item {
                                Part = new Part { Number = 4287, Color = "Red" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4289, Color = "White" },
                                Count = 1 }
                    ]
                },
                new User {
                Name ="CustomBuildSet1",
                Items =[
                        new Item {
                            Part = new Part { Number = 9023, Color = "Blue" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9286, Color = "Red" },
                            Count = 1 },
                        new Item {
                            Part = new Part { Number = 9286, Color = "White" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9289, Color = "White" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9024, Color = "Blue" },
                            Count = 5 },
                        new Item {
                            Part = new Part { Number = 19287, Color = "Red" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9289, Color = "White" },
                            Count = 1 }
                    ]
                },
                new User {
                Name ="CustomBuildSet2",
                Items =[
                        new Item {
                            Part = new Part { Number = 9023, Color = "Blue" },
                            Count = 1 },
                        new Item {
                            Part = new Part { Number = 9286, Color = "Red" },
                            Count = 1 },
                        new Item {
                            Part = new Part { Number = 9286, Color = "White" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9289, Color = "White" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9024, Color = "Blue" },
                            Count = 5 },
                        new Item {
                            Part = new Part { Number = 9287, Color = "Red" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 29289, Color = "White" },
                            Count = 1 }
                        ]
                 },
                new User {
                Name ="CustomBuildSet3",
                Items =[
                        new Item {
                            Part = new Part { Number = 9023, Color = "Blue" },
                            Count = 1 },
                        new Item {
                            Part = new Part { Number = 9286, Color = "Red" },
                            Count = 1 },
                        new Item {
                            Part = new Part { Number = 9286, Color = "White" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9289, Color = "White" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 9024, Color = "Blue" },
                            Count = 5 },
                        new Item {
                            Part = new Part { Number = 9287, Color = "Red" },
                            Count = 2 },
                        new Item {
                            Part = new Part { Number = 39289, Color = "White" },
                            Count = 1 }
                        ]
                 },
                new User {
                Name ="dr_crocodile",
                Items =[
                         new Item {
                                Part = new Part { Number = 3024, Color = "Purple" },
                                Count = 3 },
                            new Item {
                                Part = new Part { Number = 4287, Color = "Purple" },
                                Count = 2 },
                            new Item {
                                Part = new Part { Number = 4289, Color = "Purple" },
                                Count = 1 }
                        ]
                 }
                ]);
        }

        public IUser GetUserData(string userName)
        {
            return (IUser)GetUsers().Where(u => u.Name == userName).First();
        }
    }
}

