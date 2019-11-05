import React from 'react';
import './App.css';
import SelectionCounter from './Components/SelectionCounter/SelectionCounter'
import MovieOptions from './Components/MovieOptions/MovieOptions'
import ButtonStartChampionship from './Components/ButtonStartChampionship/ButtonStartChampionship'
import Container from '@material-ui/core/Container';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(2),
    textAlign: 'center',
  },
}));

function App() {
  const classes = useStyles();

  return (
    <div className="App">
      <header className="App-header">
        <div className="Text-center">
          <h5 className="title">Campeonato de filmes</h5>

          <h3>Fase de Seleção</h3>

          <hr className="line" />

          <p className="instruction">
            Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir
          </p>
        </div>
      </header>
      <Grid container direction="row" alignItems="center" spacing={1}>
        <Grid item xs={3}>
          <SelectionCounter></SelectionCounter>
        </Grid>
        <Grid item xs={9} justify="flex-end">
          <ButtonStartChampionship></ButtonStartChampionship>
        </Grid>
      </Grid>
      <Grid container direction="row" alignItems="center" >
        <MovieOptions></MovieOptions>
      </Grid>
    </div>
  );
}

export default App;
