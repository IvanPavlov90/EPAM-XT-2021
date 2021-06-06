class Storage {

    #storage = [];

    add(obj) {
        this.checkIncomingElement (obj);
        this.#storage.push(obj);
    };

    getById(id) {
        this.checkTypeOfID(id);
        let resultObj = this.#storage.find(item => item.id === id);
        if (resultObj === undefined) {
            return null;
        } else {
            return resultObj;  
        }
    };

    deleteById(id) {
        this.checkTypeOfID(id);
        let resultObj = this.#storage.find(item => item.id === id);
        if (resultObj === undefined) {
            return null;
        } else {
            let objIndex = this.#storage.indexOf(resultObj);
            this.#storage.splice(objIndex, 1);
            return resultObj;
        }
    };

    getAll() {
        this.#storage.forEach((element) => {
            console.log(element);
        })
    };

    updateById(id, data) {
        this.checkTypeOfID(id);
        if (!Array.isArray(data)) {
            throw new Error ("Data should be presented only as array")
        };
        let count = 0;
        let resultObj = this.#storage.find(item => item.id === id);
        for (let prop in resultObj) {
            if (prop !== "id") {
                resultObj[prop] = data[count];
                count++;
            }
        }
    };

    replaceById(id, obj) {
        this.checkTypeOfID(id);
        this.checkIncomingElement(obj);
        let resultObj = this.#storage.find(item => item.id === id);
        let objIndex = this.#storage.indexOf(resultObj);
        this.#storage[objIndex] = obj;
    };

    checkTypeOfID(id) {
        if (typeof id !== "string") {
            throw new Error ("id should be string only.");
        }
    };

    checkIncomingElement (obj) {
        if (typeof obj !== "object" || Array.isArray(obj)) {
            throw new Error ("You can't add anything beside object into Storage");
        } else if (!("id" in obj) || typeof obj.id !== "string") {
            throw new Error ("You can't add object without property id");
        }
    };
}

function exampleFunction() {
    try {
        /* Create stroage. */

        const footballTeams = new Storage();

        /* Add elements to storage. */

        footballTeams.add({id: "1", name: "Lyon", foundationYear: 1950});
        footballTeams.add({id: "2", name: "AC Milan", foundationYear: 1899});
        footballTeams.add({id: "3", name: "FC Barcelona", foundationYear: 1899});
        footballTeams.add({id: "4", name: "Bayer 04", foundationYear: 1904});

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
        console.log("Once again delete element with id = 3");
        console.log(footballTeams.deleteById("3"));
        console.log("Delete element with id = 4");
        console.log(footballTeams.deleteById("4"));
        console.log("Get all elements from storage to see changes.");
        footballTeams.getAll();

        /* Add antoher element and then replace the first */

        footballTeams.add({id: "3", name: "Valencia", foundationYear: 1919});
        footballTeams.replaceById("1", {id: "6", name: "Ajax", foundationYear: 1900});
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





