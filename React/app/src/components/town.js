import React, {Component} from "react"
import delhi from './delhi.jpg';
import vcold from './vcold.png';
import cold from './cold.jpg';
import sum from './sum.jpg';

class Town extends Component{
    constructor(props){
        super(props)

        this.state={
            isCal:true,
            temperature:''
        }
        this.fetchData = this.fetchData.bind(this);
    }

    fetchData() {



        fetch("http://api.openweathermap.org/data/2.5/weather?q=Delhi&APPID=3798a475fa2687ff9b93cb33fdeb4a03")
        .then(response => {
            return response.json()
        })
        .then(response => {
            // console.log(response);
            this.setState({
                temprature: response.main.temp-273.15
            })
        });
    }

    componentDidMount() {
        this.fetchData()
    }    
render() {
    return (
        <div className="mytown-container" key={this.props.name}>
            
                
            <img src={delhi} alt="delhi"  width="300" height="200"/>
            <div>
            <h1> I Live in Delhi India</h1>

        <p className="column-right">
        New Delhi is city of many histories. It is one of the big cities in India, after Mumbai and Kolkata. 
        New Delhi is one of the ancient and historical place which consists of 7 historical cities. 
        The main places in New Delhi are Connaught Place, Parliament, Secratariats, India Gate, Central Vista and many more places.
        Delhi can be said to be a very busy city that has people of  all religions, caste and colors. </p>
            
                
               {(this.state.temprature<=10)?
                <img className="Photo" src={vcold}  alt="vcold" width='70'/>
                :
                (this.state.temprature<=15)?
                <img className="Photo" src={cold}  alt="cold" width='70'/>       
                :
                <img className="Photo" src={sum}  alt="sum" width='70'/>
                }
                <div className="next">
                <b>Temprature:</b>
                {this.state.isCal
                ?
                    Math.round(this.state.temprature*100)/100+"°C "
                    :
                    Math.round((9/5*this.state.temprature+32)*100)/100+"°F "
                    }
                <button onClick={() => this.setState({ isCal: !this.state.isCal })}
                className={this.state.isCal ? "btn-capital-hide" : "btn-capital-show"}>
                {this.state.isCal ? "F" : "C"}
            </button>
           </div>
                
                </div>
        </div>
    )
}
}

export default Town;