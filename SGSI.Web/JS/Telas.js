Ext.ns("Tcc.javaScript");

Tcc.javaScript = {
    constructor: function (config) {
        Ext.apply(this, config);
    },


    login: function (email, senha) {
        SGSI.ConsultarLogin(email, senha, {
            showFailureWarning: true,
            success: function (result) {


                if (result == 2) {
                    Ext.Msg.show({
                        msg: 'Usuário ou senha incorretos, tente novamente ou entre em contato com o administrador!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });
                    WinUsuario.hide();

                }
            }
        });

    },
    criaUser: function () {
        SGSI.GenerateRandomUsername();
    },
    logout: function () {
        SGSI.Sair();
    },

    salvarNorma: function (nome, dpId, storeNormas) {
        SGSI.SalvarNorma(nome, dpId, {
            showFailureWarning: true,
            success: function (result) {

                if (result == 1) {
                    storeNormas.reload();
                    Ext.Msg.show({
                        msg: 'Norma cadastrada com sucesso!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });
                    Ext.getCmp('WinNorma').hide();
                }

                else if (result == 2) {
                    Ext.Msg.show({
                        msg: 'Esta norma já esta cadastrada no sistema!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });

                }
            },
            eventMask: {
                showMask: true,
                msg: 'Aguarde, atualizando informações...'
            }
        })
    },

    atualizarNorma: function (nome, dpId, storeNormas) {
        SGSI.AtualizarNorma(nome, dpId, {
            showFailureWarning: true,
            success: function (result) {

                if (result == 1) {
                    Ext.Msg.show({
                        msg: 'Norma atualizada com sucesso!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });
                    Ext.getCmp('WindowAtualizarNorma').hide();
                }

                else if (result == 2) {
                    Ext.Msg.show({
                        msg: 'Não foi possivel atualizar a norma!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });

                }
            },
            eventMask: {
                showMask: true,
                msg: 'Aguarde, atualizando informações...'
            }
        })
    },

    salvarProcedimento: function (nome, norma, departamento, dtInicial, dtFinal, descricao, winNorma, store) {
        SGSI.SalvarProcedimento(nome, norma, departamento, dtInicial, dtFinal, descricao, {
            showFailureWarning: true,
            success: function (result) {

                if (result == 1) {
                    Ext.Msg.show({
                        msg: 'Procedimento cadastrado com sucesso!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });
                    Ext.getCmp('WinProcedimentos').hide();
                }

                else if (result == 2) {
                    Ext.Msg.show({
                        msg: 'Esta norma já esta cadastrada no sistema!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });

                }
                store.reload();
            },
            eventMask: {
                showMask: true,
                msg: 'Aguarde, atualizando informações...'
            }
        })
    },
    abrirFormUser: function (WinUser, forUser) {

        forUser.reset();
        WinUser.show();

    },

    ManagerExit: function () {
        SGSI.Sair();
    },

    cadastroUsuario: function (departamento, nome, email, cargo, tipo, senha, WinUsuario, Usuarios) {
        SGSI.AdicionarUsuario(nome, cargo, departamento, email, tipo, senha, {
            showFailureWarning: true,
            success: function (result) {
                if (result == 1) {
                    Ext.Msg.show({
                        msg: 'Usuario adicionado com sucesso!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });
                    WinUsuario.hide();
                    Usuarios.reload();
                }

                if (resultado == 2) {
                    Ext.Msg.show({
                        msg: 'Este usuário já esta cadastrado no sistema!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });
                    WinUsuario.hide();

                }

                eventMask: {
                        showMask: true,
                        msg; 'Aguarde, atualizando informações...'
                }
            }
        }
    )
    },

    carregaFunc: function (dpId) {
        SGSI.CarregaComboFuncionario(dpId);
        Ext.getCmp('CmbNewUserNome').reset();
        Ext.getCmp('TextNewUserEmail').reset();
        Ext.getCmp('TextNewUserCargo').reset();

    },
    redimensionar: function () {
        SGSI.CarregaImagem();
    },
    carregarImagem: function () {
        SGSI.CarregaImagem();
    },

    carregarCargo: function (nome) {
        SGSI.CarregaEmailCargoFuncionario(nome);
    },

    carregaEmail: function (nome, dpId) {
        SGSI.CarregaEmailCargoFuncionario(nome, dpId);
    },

    abrirNorma: function (caminho) {
        SGSI.AbrirNorma(caminho);
    },
    gridNormas: function (command, record, WinAtualizarNorma, form, WinHistoricoNorma, formHistoricoNorma) {
        switch (command) {
            case ('Norma'):
                SGSI.AbrirNorma(record.data.Caminho);
                break;

            case ('Apagar'):
                Ext.Msg.confirm('Aviso', 'Tem certeza que gostaria de apagar esta norma', function (btn) {
                    if (btn == 'yes') {
                        SGSI.ApagarNorma(record.data.NormaId, record.data.Caminho, {
                            showFailureWarning: true,
                            success: function (result) {
                                if (result == 1) {
                                    Ext.Msg.show({
                                        msg: 'Norma apagada com sucesso!',
                                        buttons: Ext.Msg.OK,
                                        title: 'Aviso'
                                    });
                                }
                            }
                        })
                    }
                })
                break;

            case ('Atualizar'):
                form.reset();
                form.getForm().loadRecord(record);
                WinAtualizarNorma.show();
                break;


            case ('Historico'):
                formHistoricoNorma.reset();
                formHistoricoNorma.getForm().loadRecord(record);
                SGSI.CarregaHistoricoNorma(record.data.NormaId);
                WinHistoricoNorma.show();
                break;
        }
    },
    gridUsuarios: function (command, record, storeUsuarios, WinAtualizarSenha, form) {
        switch (command) {
            case ('Desativar'):
                Ext.Msg.confirm('Aviso', 'Tem certeza que gostaria de desativar usuário de ' + record.data.Nome + ' ?', function (btn) {
                    if (btn == 'yes') {
                        SGSI.AtualizarUsuario(record.data.Email, 0, {
                            showFailureWarning: true,
                            success: function (result) {
                                if (result == 1) {
                                    Ext.Msg.show({
                                        msg: 'O usuário ' + record.data.Email + ' foi desativado com sucesso!',
                                        buttons: Ext.Msg.OK,
                                        title: 'Aviso'
                                    });
                                    storeUsuarios.reload();
                                }
                            }
                        })
                    }
                })
                break;

            case ('Ativar'):
                Ext.Msg.confirm('Aviso', 'Tem certeza que gostaria de ativar o usuário de ' + record.data.Nome + ' ?', function (btn) {
                    if (btn == 'yes') {
                        SGSI.AtualizarUsuario(record.data.Email, 1, {
                            showFailureWarning: true,
                            success: function (result) {
                                if (result == 1) {
                                    Ext.Msg.show({
                                        msg: 'O usuário ' + record.data.Email + ' foi ativado com sucesso!',
                                        buttons: Ext.Msg.OK,
                                        title: 'Aviso'
                                    });
                                    storeUsuarios.reload();
                                }
                            }
                        })
                    }
                })
                break;
            case ('Senha'):
                form.reset();
                form.getForm().loadRecord(record);
                WinAtualizarSenha.show();

                break;
        }
    },

    gridProcedimentos: function (command, record, WinDetalhes, form) {
        switch (command) {
            case ('Apagar'):
                Ext.Msg.confirm('Aviso', 'Tem certeza que gostaria de apagar este procedimento?', function (btn) {
                    if (btn == 'yes') {
                        SGSI.ApagarProcedimento(record.data.ProcedimentoId, {
                            showFailureWarning: true,
                            success: function (result) {
                                if (result == 1) {
                                    Ext.Msg.show({
                                        msg: 'Procedimento apagado com sucesso!',
                                        buttons: Ext.Msg.OK,
                                        title: 'Aviso'
                                    });
                                }
                            }
                        })
                    }
                })
                break;

            case ('Detalhes'):
                SGSI.CarregaHistoricoProc(record.data.ProcedimentoId);
                form.reset();
                form.getForm().loadRecord(record);
                WinDetalhes.show();
                break;

            case ('Aceitar'):
                var progresso = (0.1 + record.data.Progresso);
                var historico = 2;
                var situacaoId = 3;
                SGSI.AtualizarProcedimento(record.data.ProcedimentoId, record.data.DepartamentoId, situacaoId, progresso, historico, {
                    showFailureWarning: true,
                    success: function (result) {
                        if (result == 1) {
                            Ext.Msg.show({
                                msg: 'Procedimento aceito com sucesso!',
                                buttons: Ext.Msg.OK,
                                title: 'Aviso'
                            });
                        }
                    }
                });
                break;

            case ('Delegar'):
                Ext.getCmp('FormDelegar').reset();
                Ext.getCmp('FormDelegar').getForm().loadRecord(record);
                Ext.getCmp('WindowDelegar').show();
                //Ext.getCmp('CmbNewUserNome').value() = null;
                //SGSI.CarregaHistoricoProc(record.data.ProcedimentoId);
                //form.reset();
                //form.getForm().loadRecord(record);
                //WinDetalhes.show();
                break;

            case ('AceitarNivel2'):
                var progresso = (0.1 + record.data.Progresso);
                var historico = 2;
                var situacaoId = 5;
                SGSI.AtualizarProcedimento(record.data.ProcedimentoId, record.data.DepartamentoId, situacaoId, progresso, historico, {
                    showFailureWarning: true,
                    success: function (result) {
                        if (result == 1) {
                            Ext.Msg.show({
                                msg: 'Procedimento aceito com sucesso!',
                                buttons: Ext.Msg.OK,
                                title: 'Aviso'
                            });
                        }
                    }
                });
                break;
            case ('Executar'):
                var progresso = (0.2 + record.data.Progresso);
                var historico = 8;
                var situacaoId = 6;
                SGSI.AtualizarProcedimento(record.data.ProcedimentoId, record.data.DepartamentoId, situacaoId, progresso, historico, {
                    showFailureWarning: true,
                    success: function (result) {
                        if (result == 1) {
                            Ext.Msg.show({
                                msg: 'Execução iniciada!',
                                buttons: Ext.Msg.OK,
                                title: 'Aviso'
                            });
                        }
                    }
                });
                break;

            case ('ConcluirExec'):

                Ext.getCmp('FormConcProce').reset();
                Ext.getCmp('FormConcProce').getForm().loadRecord(record);
                Ext.getCmp('WinConcProce').show();
                break;


            case ('AprovaProc'):
                Ext.getCmp('WinReport').show();
                SGSI.CarregarRelatorio(record.data.ProcedimentoId);
                //Ext.getCmp('WinReport').show();
                break;
        }
    },

    concluirProcedimento: function (procedimento, departamento, progressov, WinConcProc, descricao) {
        var progresso = parseFloat(progressov);
        progresso = progresso + 0.3;
        var historico = 5;
        var situacaoId = 8;
        SGSI.SalvarEvidencia(procedimento, descricao, {
            showFailureWarning: true,
            success: function (result) {
                if (result == 1) {
                    SGSI.AtualizarConcluirProcedimento(procedimento, departamento, situacaoId, progresso, historico, {
                        showFailureWarning: true,
                        success: function (result) {
                            if (result == 1) {
                                Ext.Msg.show({
                                    msg: 'Procedimeno enviado para aprovação!',
                                    buttons: Ext.Msg.OK,
                                    title: 'Aviso'
                                });
                            }
                        }
                    });
                }
            }
        });

    },

    enviarDelegar: function (user, procedimento, progressov, cargo, delegar) {
        var historico = 4;
        var situacaoId = 1;
        SGSI.DelegarProcedimento(procedimento, user, situacaoId, progressov, historico, cargo, {
            showFailureWarning: true,
            success: function (result) {
                if (result == 1) {
                    delegar.hide();
                    Ext.Msg.show({
                        msg: 'Procedimento delegado com sucesso!',
                        buttons: Ext.Msg.OK,
                        title: 'Aviso'
                    });
                }
            }
        });
    },

    alterarSenha: function (email, senha, confirmaSenha, winAtualizarSenha) {
        if (senha != confirmaSenha) {
            Ext.Msg.show({
                msg: 'As senhas não conferem!',
                buttons: Ext.Msg.OK,
                title: 'Aviso'
            });
        } else {
            SGSI.AlterarSenhaUsuario(email, senha, {
                showFailureWarning: true,
                success: function (result) {

                    if (result == 1) {
                        Ext.Msg.show({
                            msg: 'Senha alterada com sucesso',
                            buttons: Ext.Msg.OK,
                            title: 'Aviso'
                        });
                        winAtualizarSenha.hide();
                    }
                }
            })
        }
    },

    desabilitarCommandUsuarios: function (grid, toolbar, rowIndex, record) {
        var command = toolbar.items.get(0);
        var command1 = toolbar.items.get(1);
        var command2 = toolbar.items.get(2);

        if (record.data.Ativo == 0) {
            command.setHidden(true);
            command1.setHidden(false);
            command2.setHidden(true);
        }

    },

    desabilitarCommand: function (grid, toolbar, rowIndex, record) {
        var command = toolbar.items.get(0);
        var command1 = toolbar.items.get(1);
        var command2 = toolbar.items.get(2);
        var command3 = toolbar.items.get(3);
        var command4 = toolbar.items.get(4);
        var command5 = toolbar.items.get(5);
        var command6 = toolbar.items.get(6);
        var command7 = toolbar.items.get(7);
        var command8 = toolbar.items.get(8);
        var userName = Ext.getCmp('HUserName').getValue();


        ////Desabilita botão excluir para usuários que não são gestores
        //var userListaId = Ext.getCmp('hiddenUsuarioListaId').getValue();
        //var userId = Ext.getCmp('hiddenUsuarioId').getValue();
        //var arrayUser = userListaId.split(";");
        //var i, fLen;

        //fLen = arrayUser.length;
        //for (i = 0; i < fLen; i++) {
        //    if (arrayUser[i] == userId) {
        //        command2.setVisible(true);
        //    };
        //}

        if (record.data.Solicitante == userName) {
            command8.setHidden(false);
        }
        if (record.data.ResponsavelAtual == userName) {
            if (record.data.Situacao == 'Aceitação Pendente' && record.data.Progresso == 0.0) {
                command1.setHidden(false);
                command3.setHidden(false);
            }
            else if (record.data.Situacao == 'Delegação Pendente') {
                command4.setHidden(false);
            }
            else if (record.data.Situacao == 'Aceitação Pendente' && record.data.Progresso == 0.1) {
                command3.setHidden(false);
                command2.setHidden(false);
            }
      
            else if (record.data.Situacao == 'Execução Pendente' && record.data.Progresso == 0.2) {
                command5.setHidden(false);
                //command2.setHidden(false);
            }
            else if (record.data.Situacao == 'Executando') {
                command6.setHidden(false);
                //command2.setHidden(false);
            }
            else if (record.data.Situacao == 'Aprovação Pendente' && record.data.Progresso == 0.7) {
                command7.setHidden(false);
            }
        }
        //} else if (record.data.DemandaSituacaoProjeto == 'Pendente') {
        //    grid.view.addRowClass(rowIndex, 'yellow');
        //} else if (record.data.DemandaSituacaoProjeto == 'Finalizado') {
        //    grid.view.addRowClass(rowIndex, 'blue');
        //} else if (record.data.DemandaSituacaoProjeto == 'Impedido') {
        //    grid.view.addRowClass(rowIndex, 'red');
        //} else {
        //    grid.view.addRowClass(rowIndex, 'black');
        //}

    },

}