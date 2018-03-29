import React, { Component } from 'react';
import superagent from 'superagent';

export class GetWorkingTime extends Component {
    displayName = GetWorkingTime.name

    constructor(props){
    super(props);

    this.state = { logs: [], loading: false };
    }

    componentDidMount(){
    superagent.get('api/WorkingTime/WorkingTime')
          .accept('json')
          .then(
           res => {
            this.setState({ logs: res.body, loading: false  });
            }
           );
    }

    static renderLogsTable(logs){
    console.log(logs)
    return(
    <table className='table'>
        <thead>
          <tr>
            <th>Project</th>
            <th>Comments</th>
            <th>Date</th>
            <th>Time</th>
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



    render() {   
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : GetWorkingTime.renderLogsTable(this.state.logs);
        return(
        <div>
        <h1>All logged hours</h1>
        {contents}
        <br />
        <label>Total Hours: </label>
        </div>
        );

    }
}