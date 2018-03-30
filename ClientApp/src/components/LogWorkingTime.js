import React, { Component } from 'react';
import superagent from 'superagent';

export class LogWorkingTime extends Component {
    displayName = LogWorkingTime.name

    constructor(props){
    super(props);

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleProjectChange = this.handleProjectChange.bind(this);
    this.handleCommentChange = this.handleCommentChange.bind(this);
    this.handleDateChange = this.handleDateChange.bind(this);
    this.handleTimeChange = this.handleTimeChange.bind(this);

    this.state = {
    Project: '',
    Comment: '',
    Date: '',
    Time: 0
    };

    }   

    handleSubmit(event){
        superagent.post('api/LogWorkingTime/SaveWorkingTime')
        .send({
        id: 0,
        Project: this.state.Project,
        Comment: this.state.Comment,
        Date: this.state.Date,
        Time: this.state.Time
        })
        .set('Accept', 'application/json')
        .then(function(res) {
        alert('Time Saved');
        });
    }

    handleProjectChange(event){
    this.setState({Project: event.target.value});
    }

    handleCommentChange(event){
    this.setState({Comment: event.target.value});   
    }

    handleDateChange(event){
    this.setState({Date: event.target.value});   
    }

    handleTimeChange(event){
    this.setState({Time: event.target.value});   
    }

    render() {
        return(
        <div>
        <h1>Log your working time here</h1>
            <div>
            <form onSubmit={this.handleSubmit}>
                <label>Project:</label>
                <input className="form-control" onChange={this.handleProjectChange} placeholder="My project"/>
                <br />
                <label>Comments:</label>
                <br />
                <textarea rows="4" cols="100" onChange={this.handleCommentChange}/>
                <br />
                <label>Date:</label>
                <input className="form-control" onChange={this.handleDateChange} placeholder="03/25/2017"/>
                <label>Time:</label>
                <input className="form-control" type="number" onChange={this.handleTimeChange} placeholder="8 (Hours)" />
                <br />
                <button type="submit" className="btn btn-primary">Save</button>
                </form>
            </div>
        </div>
        );
    }
}