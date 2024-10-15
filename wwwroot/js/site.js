function compararAntes(anoLancamentoJogo) {
    let anoLancamentoReferencia = @MusicaReferencia.Last().AnoLancamento;

    if (anoLancamentoReferencia < anoLancamentoJogo) {
        adicionarNovaCarta();
    } else {
        tocarNovaMusica();
    }
}

function compararDepois(anoLancamentoJogo) {
    let anoLancamentoReferencia = @MusicaReferencia.Last().AnoLancamento;

    if (anoLancamentoReferencia > anoLancamentoJogo) {
        adicionarNovaCarta();
    } else {
        tocarNovaMusica();
    }
}

function adicionarNovaCarta() {
    DotNet.invokeMethodAsync('TriviaMusical', 'AdicionarNovaCarta')
        .then(() => {
            console.log('Nova música adicionada com sucesso!');
            // Aqui você pode atualizar ou manipular a interface se necessário
        })
        .catch(error => {
            console.error('Erro ao adicionar nova música:', error);
        });
}

function tocarNovaMusica() {
    if (MusicaReferencia.Any()) {
        let novaIdMusica = @MusicaReferencia.Last().IdMusica;
        document.getElementById('player-musica').src = "https://www.youtube.com/embed/" + novaIdMusica + "?autoplay=1";
    }
    else {
        adicionarNovaCarta();
    }
    
}
