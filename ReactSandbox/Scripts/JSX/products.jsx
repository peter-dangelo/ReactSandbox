var ProductCategoryRow = React.createClass({
    render: function () {
        return (
            <tr><th colSpan="2">{this.props.category}</th></tr>
        );
    }
});

var ProductRow = React.createClass({
    render: function () {
        var name = this.props.product.Stocked ?
          this.props.product.Name :
          <span style={{color: 'red'}}>
              {this.props.product.Name}
          </span>;
        return (
          <tr>
            <td>{name}</td>
            <td>{this.props.product.Price}</td>
          </tr>
        );
    }
});

var ProductTable = React.createClass({
    render: function () {
        var rows = [];
        var lastCategory = null;
        this.props.products.forEach(function (product) {
            if (product.Name.indexOf(this.props.filterText) === -1 || (!product.Stocked && this.props.restrictToInStockProducts)) {
                return;
            }
            if (product.Category !== lastCategory) {
                rows.push(<ProductCategoryRow category={product.Category} key={product.Category} />);
            }

            rows.push(<ProductRow product={product} key={product.Name } />);
            
            lastCategory = product.Category;
        }.bind(this));
        return (
          <table>
            <thead>
              <tr>
                <th>Name</th>
                <th>Price</th>
              </tr>
            </thead>
            <tbody>{rows}</tbody>
          </table>
        );
    }
});

var SearchBar = React.createClass({

    handleChange: function() {
        this.props.onUserInput(this.refs.filterText.value, this.refs.inStockOnly.checked);
    },
    render: function() {
        return (
          <form>
            <input 
                   type="text" 
                   placeholder="Search..."
                   ref="filterText"
                   value={this.props.filterText}
                   onChange={this.handleChange} />
            <p>
                <input type="checkbox"
                       checked={this.props.restrictToInStockProducts}
                       ref="inStockOnly"
                       onChange={this.handleChange} />
                {' '}
                Only show products in stock
          </p>
        </form>
      );
    }
});

var FilterableProductTable = React.createClass({
    getInitialState: function() {
        return ({
            onlyShowInStockProducts: false,
            filterText: ''
        });
    },
    handleFilterChange: function(filterText, inStockOnly) {
        this.setState({
            onlyShowInStockProducts: inStockOnly,
            filterText: filterText
        });
    },
    render: function () {
        return (
          <div>
            <SearchBar 
                restrictToInStockProducts={this.state.onlyShowInStockProducts} 
                filterText={this.state.filterText} 
                onUserInput={this.handleFilterChange}  />
            <ProductTable products={this.props.products} restrictToInStockProducts={this.state.onlyShowInStockProducts} filterText={this.state.filterText} />
        </div>
        );
    }
});