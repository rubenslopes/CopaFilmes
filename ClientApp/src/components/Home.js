import React, { Component } from 'react'
import MovieService from '../services/MovieService'
import Movie from './Movie';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props)
    this.state = {
      movies: [],
      selectedMovies: [],
    }
    this.movieService = new MovieService()

    this.compute = this.compute.bind(this)
    this.MOVIES_REQUIRED_AMOUNT = 8
  }

  compute() {
    if (this.state.selectedMovies.length !== this.MOVIES_REQUIRED_AMOUNT)
      return alert(`São necessários extamente ${this.MOVIES_REQUIRED_AMOUNT} filmes por campeonato.`)

    this.props.history.push({
      pathname: '/result',
      state: { winners: this.state.selectedMovies.splice(-2) }
    })
  }

  componentDidMount() {
    this.populateMovies()
  }

  async populateMovies() {
    const movies = await this.movieService.get()

    this.setState({ movies })
  }

  toggleMovieSelection(movie) {
    const selectedMovies = this.state.selectedMovies
    const isAdding = selectedMovies.some(m => m === movie)

    let result = []

    if (!isAdding && selectedMovies.length >= this.MOVIES_REQUIRED_AMOUNT)
      return alert(`Máximo de ${this.MOVIES_REQUIRED_AMOUNT} filmes por campeonato`)

    if (isAdding)
      result = selectedMovies.filter(m => m !== movie)
    else
      result = selectedMovies.concat([movie])

    this.setState({ selectedMovies: result })
  }

  render() {
    return (
      <div>
        <h1>Fase de Seleção</h1>
        <p>Selecione {this.MOVIES_REQUIRED_AMOUNT} filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.</p>

        <div className="Home__action-bar">
          <div>
            Selecionados {this.state.selectedMovies.length} de {this.MOVIES_REQUIRED_AMOUNT} filmes
          </div>
          <button className="btn btn-primary" onClick={this.compute}>Gerar Meu Campeonato</button>
        </div>
        <ul className="Home__movies">
          {this.state.movies.map(movie =>
            <li key={movie.id}>
              <Movie
                title={movie.titulo}
                year={movie.ano}
                checked={this.state.selectedMovies.some(m => m === movie)}
                onClick={() => this.toggleMovieSelection(movie)}
              />
            </li>
          )}
        </ul>
      </div>
    );
  }
}
