import './Result.css'
import React, { Component } from 'react'

export class Result extends Component {
  constructor(props) {
    super(props)

    console.log(this.props.history.location.state)
    this.state = this.props.history.location.state || { winners: [] }
  }

  render() {

    return (
      <div className="Result">
        <h1>Resultado Final</h1>
        <p>Veja o resultado final do Campeonato de filmes de forma simples e rápida</p>
        <ul>
          {this.state.winners.map((competitor, index) => {
            return (
              <li key={competitor.id} className="Result__item">
                <span className="Result__item-position">{`${index + 1}º`}</span>
                <span className="Result__item-title">{competitor.titulo}</span>
              </li>
            )
          })}
        </ul>
        <button className="btn" onClick={this.props.history.goBack}>Voltar</button>
      </div>
    )
  }
}