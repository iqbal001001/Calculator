import React, { Component } from 'react';

export class Calculator extends Component {
	static displayName = Calculator.name;

  constructor(props) {
    super(props);
    this.state = { number1: "", number2:"", operation: null, result: "" };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

	onSubmit =   (e) => async (op) => {
		e.preventDefault();

		this.setState({ operation: op });

		let api = null;
		let data = null;

		if (op == "Add") {
			api = "add?number1=" + this.state.number1 + "&number2=" + this.state.number2;
			data = await this.getResult(api);
		}

		if (op == "Subtract") {
			api = "subtract?number1=" + this.state.number1 + "&number2=" + this.state.number2;
			data = await this.getResult(api);
		} 

		if (op == "Multiply") {
			api = "multiply?number1=" + this.state.number1 + "&number2=" + this.state.number2;
			data = await this.getResult(api);
		}

		if (op == "Divide") {
			api = "divide?number1=" + this.state.number1 + "&number2=" + this.state.number2;
			data = await this.getResult(api);
		}
		if (op == "SplitEq") {
			api = "splitEq?number1=" + this.state.number1 + "&number2=" + this.state.number2;
			let r = await this.getResult(api) 
			data = r.join();
		}
		if (op == "SplitNum") {
			api = "splitNum?number1=" + this.state.number1 + "&number2=" + this.state.number2;
			data = await this.getResult(api);
		}
		

		this.setState({ result: data });

	}


	async getResult(api) {
	try {
		const response = await fetch('calculator/' + api);
		const data = await response.json();
		console.log(data);
		return data
	} catch (error) {
		console.log('Fetch error: ', error);
	}
}

  render() {
    return (
      <div>
        <h1>Calculator</h1>
			<form noValidate>
				<div>
					<label htmlFor="number1">Number 1</label>
					<input type="text" className="form-control" id="number1" placeholder="number 1" required
						value={this.state.number1}
						onChange={(e) => { this.setState({ number1: e.target.value }); }}
					/>
				</div>
				<div >
					<label htmlFor="number1">Number 2</label>
					<input type="text" className="form-control" id="numbeer2" placeholder="number 2" required
						value={this.state.lastName}
						onChange={(e) => { this.setState({ number2: e.target.value }); }}
					/>
				</div>
				<div >
					<label>Result</label> <span>{this.state.result}</span>
				</div>
				
				<div className="form-group row">
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Add") }} type="submit">Add</button>
					</div>
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Subtract") }} type="submit">Subtract</button>
					</div>
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Multiply") }} type="submit">Multiply</button>
					</div>
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Divide") }} type="submit">Divide</button>
					</div>
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("SplitEq") }} type="submit">SplitEq</button>
					</div>
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("SplitNum") }} type="submit">SplitNum</button>
					</div>

				</div>
			</form>
      </div>
    );
  }
}
