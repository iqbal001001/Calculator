import React, { Component } from 'react';

export class Calculator extends Component {
	static displayName = Calculator.name;

  constructor(props) {
    super(props);
    this.state = { numbers: "", operation: null, result: "" };
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
			api = "add?numbers=" + this.state.numbers;
			data = await this.getResult(api);
		}

		if (op == "Subtract") {
			api = "subtract?numbers=" + this.state.numbers;
			data = await this.getResult(api);
		} 

		if (op == "Multiply") {
			api = "multiply?numbers=" + this.state.numbers;
			data = await this.getResult(api);
		}

		if (op == "Divide") {
			api = "divide?numbers=" + this.state.numbers;
			data = await this.getResult(api);
		}
		if (op == "SplitEq") {
			api = "splitEq?numbers=" + this.state.numbers;
			let r = await this.getResult(api) 
			data = r.join();
		}
		if (op == "SplitNum") {
			api = "splitNum?numbers=" + this.state.numbers;
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
					<label htmlFor="numbers">Number Range</label>
					<input type="text" className="form-control" id="numbers" placeholder="numbers" required
						value={this.state.numbers}
						onChange={(e) => { this.setState({ numbers: e.target.value }); }}
					/>
				</div>
				<div >
					<label>Result: </label> <span>{this.state.result}</span>
				</div>
				
				<div className="form-group row">
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Add") }} type="submit">Add</button>
					</div>
					<div>
						<span>Takes two or more parameters and returns the sum of all the numbers</span>
						<br></br>
						<span>Example: 5, 2, 3, 5, 3 = 18</span>
					</div>
				</div>
					<div className="form-group row">
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Subtract") }} type="submit">Subtract</button>
					</div>
					<div>
						<span>Takes two or more parameters and returns the subtraction of the numbers</span>
						<br></br>
						<span>Example: 25, 2, 3, 5, 3 = 12</span>
					</div>
				</div>
				<div className="form-group row">
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Multiply") }} type="submit">Multiply</button>
					</div>
					<div>
						<span>Takes two or more parameters and returns the multiplication</span>
						<br></br>
						<span>Example:  2, 4, 3, 5 = 120</span>
					</div>
				</div>
				<div className="form-group row">
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("Divide") }} type="submit">Divide</button>
					</div>
					<div>
						<span>Takes two parameters and returns the division</span>
						<br></br>
						<span>Example: 16, 4 = 4</span>
					</div>
				</div>
				<div className="form-group row">
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("SplitEq") }} type="submit">SplitEq</button>
					</div>
					<div>
						<span>Takes two parameters and return the split of param1, param2 times</span>
						<br></br>
						<span>Example: 120, 4 = {30, 30, 30, 30}</span>
					</div>
				</div>
				<div className="form-group row">
					<div className="col-3">
						<button className="btn btn-primary"
							onClick={(e) => { this.onSubmit(e)("SplitNum") }} type="submit">SplitNum</button>
					</div>
					<div>
						<span>Takes two or more parameters and returns the remainder</span>
						<br></br>
						<span>Example: 140, 45, 35, 20 = 40</span>
					</div>

				</div>
			</form>
      </div>
    );
  }
}
