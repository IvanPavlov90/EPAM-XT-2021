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
            console.log("There is no element with such id, nothing to delete.");
        } else {
            let objIndex = this.#storage.indexOf(resultObj);
            this.#storage.splice(objIndex, 1);
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

/* Create stroage. */

const footballTeams = new Storage();

/* Add elements to storage. */

footballTeams.add({id: "1", name: "Lyon", foundationYear: 1950});
footballTeams.add({id: "2", name: "AC Milan", foundationYear: 1899});
footballTeams.add({id: "3", name: "FC Barcelona", foundationYear: 1899});
footballTeams.add({id: "4", name: "Bayer 04", foundationYear: 1904});

/* Check elements of our storage  and search by id */

footballTeams.getAll();
console.log(footballTeams.getById("1"));
console.log(footballTeams.getById("5"));

/* Delete some elemnts and check if it works correctly. */

footballTeams.deleteById("3");
footballTeams.deleteById("9");
footballTeams.deleteById("3");
footballTeams.deleteById("4");
footballTeams.getAll();

/* Add antoher element and then replace the first */

footballTeams.add({id: "3", name: "Valencia", foundationYear: 1919});
footballTeams.replaceById("1", {id: "6", name: "Ajax", foundationYear: 1900});
footballTeams.getAll();

/* Update element with id = 2 */

footballTeams.updateById("2", ["Manchester United", 1878,]);
footballTeams.getAll();




