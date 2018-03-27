import React, { Component } from 'react';

export class GetWorkingTime extends Component {
    displayName = GetWorkingTime.name

    constructor(props){
    super(props);
    this.state = { workinghours: [] }

    fetch('api/WorkingTime/WorkingTime')
        .then(response => response.json())
        .then(data => {
            this.setState({ workinghours: data }); 
        });
    }

    static renderAllHours (workinghours){
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
          {workinghours.map(workinghours =>
            <tr key={workinghours.Project}>
              <td>{workinghours.Comment}</td>
              <td>{workinghours.Date}</td>
              <td>{workinghours.Time}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
    }

    render() {
    let contents = GetWorkingTime.renderAllHours(this.state.workinghours);
        return(
        <div>
        <h1>All logged hours</h1>
        {contents}
        </div>
        );
    }
}