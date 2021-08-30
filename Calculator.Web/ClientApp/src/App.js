import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Calculator } from './components/Calculator';
import { ErrorBoundary } from './ErrorBoundary';

import './custom.css'

export default class App extends Component {
	static displayName = App.name;

	render() {
		return (
			<ErrorBoundary>
				<Layout>
					<Route exact path='/' component={Calculator} />
				</Layout>
			</ErrorBoundary>
		);
	}
}
