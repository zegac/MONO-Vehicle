import React, { Component } from "react";

class Home extends Component {
  render() {
    return (
      <div>
        <header className="header">
          <a href="/home">Home</a><br/>
          <a href="/models">Models</a><br/>
          <a href="/makes">Make</a>
        </header>
      </div>
    );
  }
}

export default Home;
