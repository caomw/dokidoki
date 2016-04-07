LanguageDokiScriptView = require './language-doki-script-view'
{CompositeDisposable} = require 'atom'

module.exports = LanguageDokiScript =
  languageDokiScriptView: null
  modalPanel: null
  subscriptions: null

  activate: (state) ->
    @languageDokiScriptView = new LanguageDokiScriptView(state.languageDokiScriptViewState)
    @modalPanel = atom.workspace.addModalPanel(item: @languageDokiScriptView.getElement(), visible: false)

    # Events subscribed to in atom's system can be easily cleaned up with a CompositeDisposable
    @subscriptions = new CompositeDisposable

    # Register command that toggles this view
    @subscriptions.add atom.commands.add 'atom-workspace', 'language-doki-script:toggle': => @toggle()

  deactivate: ->
    @modalPanel.destroy()
    @subscriptions.dispose()
    @languageDokiScriptView.destroy()

  serialize: ->
    languageDokiScriptViewState: @languageDokiScriptView.serialize()

  toggle: ->
    console.log 'LanguageDokiScript was toggled!'

    if @modalPanel.isVisible()
      @modalPanel.hide()
    else
      @modalPanel.show()
