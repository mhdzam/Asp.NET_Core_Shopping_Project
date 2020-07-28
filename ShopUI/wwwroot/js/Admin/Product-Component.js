Vue.component('productmanager', {
    template: `<div v-if="!editing">
                <button @click="newProduct" class="button is-success">New Product</button>
                <table class="table">
                    <tr>
                        <td>Id</td>
                        <td>Name</td>
                        <td>Value</td>
                    </tr>
                    <tr v-for="(product, index) in products">
                        <td>{{product.id}}</td>
                        <td>{{product.name}}</td>
                        <td>{{product.value}}</td>
                        <td><a @click="editProduct(product.id, index)">Update</a></td>
                        <td><a @click="deleteproducts(product.id, index)">Remove</a></td>
                    </tr>
                </table>
            </div>
            <div v-else>

                <div class="field">
                    <label class="label"> product name</label>
                    <div class="control">
                        <input class="input" v-model="productModel.name" placeholder="Product name" />
                    </div>
                </div>

                <div class="field">
                    <label class="label"> product description</label>
                    <div class="control">
                        <input class="input" v-model="productModel.description" placeholder="Product description" />
                    </div>
                </div>

                <div class="field">
                    <label class="label"> product Value</label>
                    <div class="control">
                        <input class="input" v-model="productModel.value" placeholder="Product Value" />
                    </div>
                </div>
                <button class="button is-success" @click="createProduct" v-if="!productModel.id">Create Product</button>
                <button class="button is-warning" @click="updateProduct" v-else>Update Product</button>
                <button class="button" @click="cancel">Cancel</button>
            </div>`,
    data() {
        return {
            editing: false,
            loading: false,
            objectIndex: 0,
            productModel: {
                Id: 0,
                Name: "product name",
                Description: "product description",
                Value: '1.99'
            },
            products: []
        }
    },
    mounted() {
        this.getproducts();
    },
    methods: {
        getproduct(id) {
            this.loading = true;
            axios.get('/Admin/Products/' + id)
                .then(res => {
                    console.log('success get product');
                    console.log(res);
                    var product = res.data;
                    console.log(product);
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        value: product.value
                    };
                    console.log("this is the Model: " + this.productModel);
                    console.log("this is the Model: " + this.productModel.name);
                    console.log("this is the Model: " + this.productModel.description);
                    console.log("this is the Model: " + this.productModel.value);

                })
                .catch(err => {
                    console.log('failed');
                    console.log(err);
                })
                .then(() => {
                    console.log('THEN !!!');

                    this.loading = false;
                });
        },
        getproducts() {
            this.loading = true;
            axios.get('/Admin/Products')
                .then(res => {
                    console.log('success HI');
                    console.log(res.data);
                    this.products = res.data;

                })
                .catch(err => {
                    console.log('failed');
                    console.log(err);
                })
                .then(() => {
                    console.log('THEN !!!');

                    this.loading = false;
                });
        },
        deleteproducts(id, index) {
            this.loading = true;
            axios.delete('/Admin/Product/' + id)
                .then(res => {
                    console.log('success');
                    console.log(res.data);
                    this.products.splice(this.objectIndex, 1)

                })
                .catch(err => {
                    console.log('failed');
                    console.log(err);
                })
                .then(() => {
                    console.log('THEN !!!');

                    this.loading = false;
                });
        },
        createProduct() {
            this.loading = true;
            axios.post("/Admin/Product", this.productModel)
                .then(res => {
                    console.log(res.data);

                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);

                })
                .then(() => {

                    this.loading = false;
                });

        },
        updateProduct() {
            this.loading = true;
            axios.post("/Admin/updateProducts", this.productModel)
                .then(res => {
                    console.log(res.data);

                    this.products.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);

                })
                .then(() => {

                    this.loading = false;
                    this.editing = false;
                });

        },
        editProduct(id, index) {
            console.log('Hi from edit');
            this.objectIndex = index;
            this.getproduct(id);
            console.log(id);
            console.log(index);
            console.log(' value od current item is: ' + this.productModel.value);
            this.editing = true;
        },
        newProduct() {
            this.editing = true;
            this.productModel.id = 0;
        },
        cancel() {
            this.editing = false;
        }

    },
    computed: {
    }
});