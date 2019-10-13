class MovieService {
  async get() {
    const response = await fetch('https://copadosfilmes.azurewebsites.net/api/filmes')

    return await response.json()
  }
}

export default MovieService