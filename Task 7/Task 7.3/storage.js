export { Storage }

class Storage {

    _storage = [];
    _idCount = 1;

    add(obj) {
        this.checkIncomingElement(obj);
        this.getObjectID(obj);
        this._storage.push(obj);
    };

    getById(id) {
        this.checkTypeOfID(id);
        let resultObj = this._storage.find(item => item.id === id);
        if (resultObj === undefined) {
            return null;
        } else {
            return resultObj;  
        }
    };

    deleteById(id) {
        this.checkTypeOfID(id);
        let resultObj = this._storage.find(item => item.id === id);
        if (resultObj === undefined) {
            return null;
        } else {
            let objIndex = this._storage.indexOf(resultObj);
            this._storage.splice(objIndex, 1);
            return resultObj;
        }
    };

    getAll() {
        this._storage.forEach((element) => {
            console.log(element);
        })
    };

    updateById(id, data) {
        this.checkTypeOfID(id);
        if (!Array.isArray(data)) {
            throw new Error ("Data should be presented only as array")
        };
        let count = 0;
        let resultObj = this._storage.find(item => item.id === id);
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
        let resultObj = this._storage.find(item => item.id === id);
        obj.id = id;
        let objIndex = this._storage.indexOf(resultObj);
        this._storage[objIndex] = obj;
    };

    getObjectID(obj) {
        obj.id = this._idCount.toString();
        this._idCount++;
    };

    checkTypeOfID(id) {
        if (typeof id !== "string") {
            throw new Error ("id should be string only.");
        }
    };

    checkIncomingElement (obj) {
        if (typeof obj !== "object" || Array.isArray(obj)) {
            throw new Error ("You can't add anything beside object into Storage");
        }
    };
}