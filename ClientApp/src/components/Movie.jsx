import './Movie.css'
import React from 'react'

const Movie = props => {
  const className = `Movie ${props.checked ? `Movie--selected` : ``}`

  return <label tabIndex="0" htmlFor={props.id} className={className} >
    <input tabIndex="-1" className="Movie__checkbox" id={props.id} type="checkbox" checked={props.checked} onChange={props.onClick} />
    <span className="Movie__datas">
      <span className="Movie__title">{props.title}</span>
      <span className="Movie__year">{props.year}</span>
    </span>
  </label>
}

export default Movie