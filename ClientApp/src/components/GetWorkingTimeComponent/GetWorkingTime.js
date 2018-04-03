import React, { Component } from 'react';
import superagent from 'superagent';
import './GetWorkingTime.css';

export class GetWorkingTime extends Component {
    displayName = GetWorkingTime.name

    constructor(props){
    super(props);

    this.handleFilterChange = this.handleFilterChange.bind(this)

    this.state = { 
        logs: [],
        filter: '', 
        loading: true 
        };
    }

    componentDidMount(){

    superagent.get('api/GetWorkingTime/GetWorkingTimes')
          .accept('json')
          .then(
           res => {
            this.setState({ logs: res.body, loading: false  });
            }
           );
    }

    static renderLogsTable(logs, filter){

    if(filter !== ''){
        var filterVal = filter.trim().toLowerCase()
        if(filterVal.length > 0){
            logs = logs.filter(l => {
                return l.project.toLowerCase().match( filterVal );

            });
        }
    }

    return(
    <table className='table'>
        <thead>
          <tr>
            <th>Project</th>
            <th>Comments</th>
            <th>Date</th>
            <th>Time (hours)</th>
          </tr>
        </thead>
        <tbody>
          {logs.map(log =>
            <tr key={log.id}>
              <td>{log.project}</td>
              <td>{log.comment}</td>
              <td>{log.date}</td>
              <td>{log.time}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
    }

    handleFilterChange(event){
        this.setState({ filter: event.target.value });   
    }

    render() {   

    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : GetWorkingTime.renderLogsTable(this.state.logs, this.state.filter);

        return(
        <div>
        <h1>All logged hours.</h1>
        <label>Filter:</label>
        <input className="form-control" type="text" onChange={this.handleFilterChange} placeholder="Project name" />
        <br />
        {contents}
        </div>
        );

    }
}
