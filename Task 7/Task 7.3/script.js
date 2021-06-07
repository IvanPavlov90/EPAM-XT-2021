import { Storage } from '/storage.js'

function exampleFunction() {
    try {
        /* Create stroage. */

        const footballTeams = new Storage();

        /* Add elements to storage. */

        footballTeams.add({name: "Lyon", foundationYear: 1950});
        footballTeams.add({name: "AC Milan", foundationYear: 1899});
        footballTeams.add({name: "FC Barcelona", foundationYear: 1899});
        footballTeams.add({name: "Bayer 04", foundationYear: 1904});

        /* Check elements of our storage and search by id */

        console.log("Get all elements from storage.");
        footballTeams.getAll();
        console.log("Object with id = 1");
        console.log(footballTeams.getById("1"));
        console.log("Object with id = 5");
        console.log(footballTeams.getById("5"));

        /* Delete some elemnts and check if it works correctly. */

        console.log("Delete element with id = 3");
        console.log(footballTeams.deleteById("3"));
        console.log("Delete element with id = 9");
        console.log(footballTeams.deleteById("9"));
        console.log("Once again delete element with id = 3 (returns null, because such element was deleted earlier.)");
        console.log(footballTeams.deleteById("3"));
        console.log("Delete element with id = 4");
        console.log(footballTeams.deleteById("4"));
        console.log("Get all elements from storage to see changes.");
        footballTeams.getAll();

        /* Add antoher element and then replace the first */

        footballTeams.add({name: "Valencia", foundationYear: 1919});
        footballTeams.replaceById("1", {name: "Ajax", foundationYear: 1900});
        console.log("Get all elements from storage to see changes after adding new element and replacing element with id = 1.");
        footballTeams.getAll();

        /* Update element with id = 2 */

        footballTeams.updateById("2", ["Manchester United", 1878]);
        console.log("Get all elements from storage to see changes after updating element with id = 2.");
        footballTeams.getAll();
    } catch (e) {
        console.log(e.message);
    }
};

exampleFunction();





