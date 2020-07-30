var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedproduct: null,
        newStock: {
            productId: 0,
            description: "Size",
            qty: 10,
        }
    },
    mounted() {
        this.getstock();
    }
    ,
    methods: {
        getstock() {
            this.loading = true;
            axios.get('/Admin/stocks/')
                .then(res => {
                    
                    this.products = res.data;
                    console.log(res.data);
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
        deletestock(id,index) {
            this.loading = true;
            axios.delete('/Admin/stock/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedproduct.stock.splice(index,1);
                    console.log(product);
                })
                .catch(err => {
                    console.log('failed');
                    console.log(err);
                })
                .then(() => {
                    console.log('THEN !!!');

                    this.loading = false;
                })
        },
        updatestock() {
            this.loading = true;
            var vm = this.selectedproduct.stock.map(x => {
                return {
                    id: x.id,
                    description: x.description,
                    qty: x.qty,
                    productid: this.selectedproduct.id
                };
            });
            console.log(vm);
            
            axios.put('/Admin/stock/', {stock: vm})
                .then(res => {
                    console.log(res);
                    var products = res.data;
                    console.log(product);
                })
                .catch(err => {
                    console.log('failed');
                    console.log(err);
                })
                .then(() => {
                    console.log('THEN !!!');

                    this.loading = false;
                })
        },
        selectProduct(product) {
            this.selectedproduct = product;
            this.newStock.productId = product.id;
            console.log(product);
        },
        AddStock() {
            this.loading = true;
            console.log('model view q :  ' + typeof this.newStock.qty);
            console.log('model view pid :  ' + typeof this.newStock.productId);
            console.log('model view desc :  ' + typeof this.newStock.description);
            axios.post('/Admin/stock/', this.newStock)
                .then(res => {
                    console.log(res);
                    this.selectedproduct.stock.push(res.data);
                    console.log(product);
                })
                .catch(err => {
                    console.log('failed');
                    console.log(err);
                })
                .then(() => {
                    console.log('THEN !!!');

                    this.loading = false;
                })
        }
    }
})