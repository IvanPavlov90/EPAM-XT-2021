class Storage {

    _storage = [];

    add(obj) {
        if (typeof obj !== "object" || Array.isArray(obj)) {
            console.log("You can't add anything beside object into Storage");
        } else {
            this._storage.push(obj);
        }
    }

    getbyId(id) {
        if (typeof id !== "string") {
            console.log("ID should be string only.");
            return null;
        } else if (+id >= this._storage.length) {
            return null;
        } else {
            return this._storage[id];
        }
    }

    getAll() {
        return this._storage;
    }
}

const transferBudget = new Storage();

transferBudget.add({"Juventus" : "$ 30 000 000"});
transferBudget.add({"AC Milan" : "$ 25 000 000"});
transferBudget.add({"InterMilan" : "$ 25 000 000"});
transferBudget.add({"Napoli" : "$ 22 000 000"});
console.log(transferBudget.getAll());
console.log(transferBudget.getbyId("1"));
console.log(transferBudget.getbyId(null));