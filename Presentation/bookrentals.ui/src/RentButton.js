import React, { Component } from 'react';

class RentButton extends Component {
    constructor(props) {
      super(props);
      this.rented = this.props.rented;
      this.handleClick = this.handleClick.bind(this);
    }
  
    handleClick() {
      this.setState(prevState => ({
        rent: !prevState.isToggleOn
      }));
    }
  
    render() {
      return (
        // <button onClick={this.handleClick}>
        //   {this.state.isToggleOn ? 'ON' : 'OFF'}
        // </button>
        <button
            type="button"
            className="btn btn-primary btn-sm"
            data-bs-toggle="modal"
            data-bs-target="#rentModal"
            onClick={this.rented}>Kirala</button>
      );
    }
  }

  export default RentButton;