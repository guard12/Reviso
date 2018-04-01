import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { LogWorkingTime } from './components/LogWorkingTimeComponent/LogWorkingTime';
import { GetWorkingTime } from './components/GetWorkingTimeComponent/GetWorkingTime';


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/logworkingtime' component={LogWorkingTime} />
        <Route path='/getworkingtime' component={GetWorkingTime} />
      </Layout>
    );
  }
}
