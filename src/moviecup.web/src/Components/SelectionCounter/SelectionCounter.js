import React, { Component } from 'react';
import './SelectionCounter.css'

export default class SelectionCounter extends Component {
    constructor(props) {
        super(props);
        this.state = {
            counter: 0
        };
        this.selectedCounter = this.selectedCounter.bind(this);
    }

    selectedCounter() {
        return 0;
    }

    render() {
        return (
            <div className="selection-counter">
                Selecionados {this.state.counter} de 8 filmes
            </div>
        );
    }
}
