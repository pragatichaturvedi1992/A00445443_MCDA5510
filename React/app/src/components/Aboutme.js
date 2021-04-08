import React, { Component } from "react"
import prag from './img.jpeg';

class Aboutme extends Component{
    render(){
        return(
            <div className="Aboutme-container" >
                <img src={prag} alt="prag" width="100" height="200"/>
                <div className="id">
                    <h1> Hi, I'm Pragati Chaturvedi</h1>
                <p>I'm student of MSCDA program in Saint Mary's university. </p>

                <p>
                
                I joined to this course to build knowlege and proficiency in DataAnalytics and looking forward for collaboration 
               
                </p>
                </div>
            </div> 

        );
    }
}

export default Aboutme;