import React, { Component } from "react"
import Aboutme from './components/Aboutme'
import Town from './components/town'
import './App.css';

class App extends Component
 {
  constructor(props) {
    super(props)
    this.state = {
      selectedMenu: 'a'
    }
  }
  render() {
    return (
      <div className="app-container">
      
        <div className="App-Header">
          <ol onClick={() => this.setState({ selectedMenu: 'a' })}>AboutMe</ol>
          <ol onClick={() => this.setState({ selectedMenu: 'h' })}>Mytown</ol>

        </div>
        
        {this.state.selectedMenu === 'a' ? 
        <Aboutme/>:<Town/>
        }
      </div>
    );
  }
}

export default App;
