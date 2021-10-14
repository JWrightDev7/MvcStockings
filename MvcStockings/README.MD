Stocking supply store site creation

Started out with creating a list of stocking types as well as a list of images, prices, and ratings for each stocking type.

After gathering all the information for the site the site creation began.  

After creating the base site from the Mvc template with changed values to work with the stocking sales site I added a new view which was created for the About page.
After creating the about page I moved onto making the model to allow me to create the database table to keep the stockings information in. This step also included scaffolding
to create the Create, Read, Update and Delete Pages used with the database.

After scaffolding was complete I created the initial migration for the database so that the database table is up to date.
Once scaffolding and migration was all complete I created the SeedData.cs file which allows me to seed the table in the database with information so that it is not empty and 
so that each item does not need to be added manually.

Once the SeedData.cs file is created I then worked on creating the initializer that actually commits the seed data into the table of the database.

After making sure all the seed data worked correctly and the table was seeded I moved on to adding a search and filter function to the product page to be able to search by
name of stocking and filter by type of stockings allowing the user to find exactly what they are looking for.

Once the search and filter was working I then worked on validation for editing the entries in the table to make sure the correct type of information was input into the table.

After all the core functions were finished I then started to work on changing some of the styling to customize the look of the site.  I also added links from the main home page
to the details page of each different type of stocking by clicking on the image of the stocking the user would like to see information on.