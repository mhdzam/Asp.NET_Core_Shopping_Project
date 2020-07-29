var app = new Vue({
    el: '#app',
    data: {
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