# Gilded Rose API

### Prerequisites

- [Git](https://git-scm.com/downloads)
- [Visual Studio 2022 - Community](https://visualstudio.microsoft.com/vs/community/)
- [Mozilla Firefox](https://www.mozilla.org/en-US/firefox/new/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [DBeaver](https://dbeaver.io/download/)

### Cloning the Repository

Go to the [repository](https://github.com/MindShaver/gilded-rose-backend) and click the big `<> Code` button.

![image](https://github.com/MindShaver/gilded-rose-backend/assets/16137173/c22371b1-7763-4b8f-a668-a301fa44df5b)

Create a new folder on your desktop and name it `Repositories`.

Open git bash and run the following command -

`cd Desktop/Repositories`

Now, using the link you copied from Github run this command to clone the repo -

`git clone https://github.com/MindShaver/gilded-rose-backend.git`

If everything worked correctly you should now see a folder in your Repositories folder called `gilded-rose-backend`

Run the command `cd gilded-rose-backend` to navigate to the project.

Congratulations! You've cloned the repository.

### Starting the API and building the Database

Make sure you are in the correct folder inside of Git Bash. It should say something like `~/Desktop/Repositories/gilded-back-end/gilded-rose-backend (main)`

Make sure Docker Desktop is running and run the command `docker-compose build`. This should run for a minute and spit out a lot of logs.

Once it is done you are ready to run the containers. Start them by using the commmand `docker-compose up`.

You must leave the Git Bash terminal running for as long as you want the API running. If you close the terminal it will stop the application.

You can stop the application by pressing Ctrl+C in the Git Bash terminal.

To verify that application is running open Mozilla and navigate to `http://localhost:8888/swagger/index.html`. This is the Swagger Documentation for the API. You'll use this to interact with the API and test "endpoints".

Now, onto viewing our Database.

### Viewing the Database

At this point you should have the application running. You can open Docker Desktop and see two containers with green statuses -

// Insert picture of Docker Desktop

Open DBeaver.

Click the "Add New Database" button and select `PostgreSQL` as the database.

`Host = localhost`
`Port = 5432`
`Database = gilded-db`
`Username = postgres`
`Password = password`

Click the Test Connection button to verify there is a connection. Click Finish and you should see a new database in the navigation window named gilded-db.

Expand the arrow: `gilded-db -> Databases -> gilded-db -> Schemas -> public -> tables`

Right click on the Items table and click "View Data". You should see an empty table with columns labeled - `Id - Name - Sellin - Quality - etc..`

Onto the last step for now - Seeding the Database and verifying.

### Seed the Database

With the docker containers still running open Mozilla and go to Swagger - `http://localhost:8888/swagger/index.html`

Scroll down to the POST Seed line and expand it. Click the Try It Out! button. Click the Execute button.

This fires off a request to add some fake data to our database. Let's go back to DBeaver and verify.

Right click on our `Items` table and click "View Data". If nothing shows up right click the "Items" table and click "Refresh". The default items should now show up in the table.

Lastly, lets go back to swagger and expand the `GET /Items` line. Click "Try it out" and "Execute". You should see a response containing all the items you just saw in the database as JSON.

### Conclusion

Congratulations! You've set up your local development/testing environment. Feel free to mess around with the other endpoints in Swagger. Currently you have the ability to:

- See all items
- See a single item by providing an `Id`
- Delete ALL items
- Delete a single item by `Id`
- Create an item by providing `Name, Quality, Quantity, and Sellin`
- Seed default data
- Run the Gilded Rose Daily Update (check out the next section for this)

## The Gilded Rose

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We have a system in place that updates our inventory for us. It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures.

We need some Quality Assurance help on this project. We don't know for sure that all the functionality is working correctly. It is up to you to come up with test cases to verify the `System Documentation`.

Use the Swagger page to create specific scnearios, run the process and verify that things update correctly. Verify both in Swagger and in the Database itself.

### System Documentation

- All items have a **SellIn** value which denotes the number of days we have
  to sell the item
- All items have a **Quality** value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, `Quality` degrades _twice as fast_
- The `Quality` of an item is never negative
- "Aged Brie" actually _increases_ in `Quality` the older it gets
- The `Quality` of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases
  in `Quality`
- "Backstage passes", like aged brie, increases in `Quality` as it's `SellIn`
  value approaches; `Quality` increases by 2 when there are 10 days or less
  and by 3 when there are 5 days or less but `Quality` drops to 0 after the
  concert

When you run the `Process` endpoint in Swagger it will simulate a day change and these rules should apply to all items.

Just for clarification, an item can never have its Quality increase
above 50, however "Sulfuras" is a legendary item and as such its
Quality is 80 and it never alters.
