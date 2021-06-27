import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { PlaceRobot } from './components/PlaceRobot';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={PlaceRobot} />                       
      </Layout>
    );
  }
}
