var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        productModel: {
            Name: "product name",
            Description: "product description",
            Value: "1.99"
        },
        products: []
    },
    methods: {
        getproducts() {
            this.loading = true;
            axios.get('/Admin/Products')
                .then(res => {
                    console.log('success');
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
        createProduct() {
            this.loading = true;
            axios.post("/Admin/Product", this.productModel)
                .then(res => {
                    console.log(res.data);
                    console.log('success !!!');
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                    console.log('catch !!!');
                })
                .then(() => {
                    console.log('THEN !!!');
                    this.loading = false;
                });

        }
  
    },
    computed: {
    }
});