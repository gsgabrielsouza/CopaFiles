import React, { useEffect, useState } from 'react';
import Button from '@material-ui/core/Button';
import { withStyles, makeStyles } from '@material-ui/core/styles';
import './ButtonStartChampionship.css'
const axios = require('axios').default;

const ButtonStartChampionship = () => {
    const useStyles = makeStyles(theme => ({
        button: {
            margin: theme.spacing(1),
        },
        input: {
            display: 'none'
        }
    }));

    const BootstrapButton = withStyles({
        root: {
            textTransform: 'none',
            fontSize: 16,
            padding: '6px 12px',
            border: '1px solid',
            lineHeight: 1.5,
            backgroundColor: '#343434',
            borderColor: '#343434',
            '&:hover': {
                backgroundColor: '#666462',
                borderColor: '#666462',
                boxShadow: 'none',
            },
            '&:active': {
                boxShadow: 'none',
                backgroundColor: '#848280',
                borderColor: '#848280',
            },
            display: 'flex',
            marginLeft: 'auto'
        },
    })(Button);

    const handleStart = () => {
        // fetch("http://localhost:5000/v1/movies", { method: 'GET', mode: 'no-cors' })
        //     .then((response) => {

        //     })
        debugger
        axios.get('http://localhost:5000/v1/movies', {

        })
            .then(function (response) {
                console.log(response.data)
            })
            .catch(err => {
                console.log(err)
            })


    }

    const classes = useStyles();
    return (
        <BootstrapButton variant="contained" color="primary" disableRipple className={classes.margin} onClick={handleStart}>
            GERAR MEU CAMPEONATO
        </BootstrapButton>
    )
}

export default ButtonStartChampionship