class MovieCupService {
  async getCompetitors() {
    const response = await fetch('https://copadosfilmes.azurewebsites.net/api/filmes')

    return await response.json()
  }

  async result(movies) {
    const response = await fetch('/moviecup', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(movies)
    })

    return await response.json()
  }
}

export default MovieCupService