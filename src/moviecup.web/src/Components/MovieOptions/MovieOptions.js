import React, { Component, useEffect, useState } from 'react';
import './MovieOptions.css'
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import Checkbox from "@material-ui/core/Checkbox";
import { Grid, Paper } from '@material-ui/core';
import axios from 'axios';
import { makeStyles, createStyles, Theme } from "@material-ui/core/styles";

const useStyles = makeStyles(() =>
  createStyles({
    root: {
      flexGrow: 1
    },
    paper: {
    padding: '1',
      textAlign: "center",
    }
  })
);

const MovieOptions = () => {
    const classes = useStyles()

    const movies = [
        {
            "id": "tt3606756",
            "title": "Os Incríveis 2",
            "year": 2018,
            "score": 8.5
        },
        {
            "id": "tt4881806",
            "title": "Jurassic World: Reino Ameaçado",
            "year": 2018,
            "score": 6.7
        },
        {
            "id": "tt5164214",
            "title": "Oito Mulheres e um Segredo",
            "year": 2018,
            "score": 6.3
        },
        {
            "id": "tt7784604",
            "title": "Hereditário",
            "year": 2018,
            "score": 7.8
        },
        {
            "id": "tt4154756",
            "title": "Vingadores: Guerra Infinita",
            "year": 2018,
            "score": 8.8
        },
        {
            "id": "tt5463162",
            "title": "Deadpool 2",
            "year": 2018,
            "score": 8.1
        },
        {
            "id": "tt3778644",
            "title": "Han Solo: Uma História Star Wars",
            "year": 2018,
            "score": 7.2
        },
        {
            "id": "tt3501632",
            "title": "Thor: Ragnarok",
            "year": 2017,
            "score": 7.9
        },
        {
            "id": "tt2854926",
            "title": "Te Peguei!",
            "year": 2018,
            "score": 7.1
        },
        {
            "id": "tt0317705",
            "title": "Os Incríveis",
            "year": 2004,
            "score": 8
        },
        {
            "id": "tt3799232",
            "title": "A Barraca do Beijo",
            "year": 2018,
            "score": 6.4
        },
        {
            "id": "tt1365519",
            "title": "Tomb Raider: A Origem",
            "year": 2018,
            "score": 6.5
        },
        {
            "id": "tt1825683",
            "title": "Pantera Negra",
            "year": 2018,
            "score": 7.5
        },
        {
            "id": "tt5834262",
            "title": "Hotel Artemis",
            "year": 2018,
            "score": 6.3
        },
        {
            "id": "tt7690670",
            "title": "Superfly",
            "year": 2018,
            "score": 5.1
        },
        {
            "id": "tt6499752",
            "title": "Upgrade",
            "year": 2018,
            "score": 7.8
        }
    ];
    // debugger
    // axios.get('http://localhost:5000/v1/movies', {
    //     headers: { 'Access-Control-Allow-Origin': '*' }
    // })
    //     .then((response) => {
    //         movies = response.data;
    //         console.log(movies);
    //     });

    return (
        <List >
            <Grid container spacing={3}>
                {movies.map((value, index) => {
                    const labelId = `${value.id}`;
                    return (
                        <Grid item xs={4}>
                            <Paper className={classes.paper}>
                                <ListItem
                                    key={index}
                                    role={undefined}
                                    dense
                                    button
                                >
                                    <ListItemIcon>
                                        <Checkbox
                                            color="default"
                                            value="checkedG"
                                        />
                                    </ListItemIcon>
                                    <ListItemText
                                        id={labelId} primary={`${value.title}`}
                                    />
                                </ListItem>
                            </Paper>
                        </Grid>
                    );
                })}
            </Grid>
        </List>
    );
}

export default MovieOptions