# This is docker swarm run in two backend docker services plus one nginx load balance docker service to demostrate the scale up of back end service
# System requirement:
1. C# .NET Core 8 with Visual Studio 2022 
2. Docker Desktop (Windows)
3. 

Test Run:
1. Start the command : docker compose up  ( Path is in ./LegoInventoryCheck/Docker/docker-compose.yml)
2. http://localhost:8080/swagger/index.html 

Below is the test for the accessment :

  //Q0 Which sets can the user brickfan35 build with their exisiting inventory of pieces?
  
  swagger get /api/LegoInventory/GetUserCatalogueCapability    
  
    Paramaters : 
     userName: brickfan35
     ignoreColor: false

  //Q1 The user landscape-artist doesn't have the right pieces to build the set tropical-island but would like to collaborate with other users on the build.
  //   Which users could they combine their collection with to have the complete piece requirements for the build?
  
  swagger get /api/LegoInventory/CheckUserSetHelpers

    Paramaters : 
      userName: landscape-artist
      userSet: tropical-island
      ignoreColor: false 

  //Q2 The user megabuilder99 is interested in creating a new custom build but they want to make sure other people could complete it with their current inventories.
  //   What is the largest collection of pieces they should restrict themselves to
  //   if they want to ensure that at least 50% of other users could complete the build?

  swagger get /api/LegoInventory/CustomItemsWithTargetUserRate
  
    Paramaters : 
      rate: 50

   // Q3 (HARD) The user dr_crocodile wants to expand the number of sets they can build with their current inventory and are prepared to be flexible on the colour scheme.
  // They are happy to substitute any colour in a set as long as all the pieces of that colour are substituted, and that the new colour isn't used elsewhere in the set. For example,
  // a building with white walls, a red roof and a green flag could be built with red walls, a blue roof and a green flag. What new sets can dr_crocodile build by allowing colour substitutions?

   swagger get /api/LegoInventory/GetUserCatalogueCapability
  
    Paramaters : 
      userName: dr_crocodile
      ignoreColor: true