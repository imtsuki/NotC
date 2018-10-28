'use babel';

import React from 'react';
import {CompositeDecorator, Editor, EditorState, RichUtils} from 'draft-js';

var request = require('request');
var rp = require('request-promise');
var tokens = [{kind: 'EOF', position: -1, length: -1}];
var finished = true;

export default class Main extends React.Component {
  constructor(props) {
    super(props);
    const decorator = new CompositeDecorator([
      {
        strategy: identifierStrategy,
        component: IdentifierSpan,
      },
      {
        strategy: keywordStrategy,
        component: KeywordSpan,
      },
      {
        strategy: operatorStrategy,
        component: OperatorSpan,
      },
      {
        strategy: intStrategy,
        component: IntSpan,
      },
    ]);
    this.state = {editorState: EditorState.createEmpty(decorator)};
    this.onChange = (editorState) => {
      if (this.state.editorState.getCurrentContent() !== editorState.getCurrentContent()) {
        finished = false;
        const text = editorState.getCurrentContent().getPlainText();
      var postData = {"text": text};
      console.log(text);
      request({
        uri: "https://localhost:5001/api/parse",
        method: "POST",
        "rejectUnauthorized": false, 
        json: postData
      }, function (error, response, body){
        tokens = body;
        finished = true;
      });
      }
      this.setState({editorState});

    };
    this.handleKeyCommand = this.handleKeyCommand.bind(this);
  }
  handleKeyCommand(command, editorState) {
    const newState = RichUtils.handleKeyCommand(editorState, command);
    if (newState) {
      this.onChange(newState);
      return 'handled';
    }
    return 'not-handled';
  }
  _onBoldClick() {
    this.onChange(RichUtils.toggleInlineStyle(this.state.editorState, 'BOLD'));
  }
  render() {
    return (
      <div style={styles.root}>
        <button onClick={this._onBoldClick.bind(this)}>Bold</button>
        <Editor
          editorState={this.state.editorState}
          handleKeyCommand={this.handleKeyCommand}
          ref = "editor"
          onChange={this.onChange}
        />
      </div>
    );
  }
}

const HANDLE_REGEX = /\@[\w]+/g;
const HASHTAG_REGEX = /\#[\w\u0590-\u05ff]+/g;

function handleStrategy(contentBlock, callback, contentState) {
  findWithRegex(HANDLE_REGEX, contentBlock, callback);
}

function identifierStrategy(contentBlock, callback, contentState) {
  if (!finished) return;
  tokens.forEach(token => {
        console.log(token);
      if (token.kind === 'IDENTIFIER') {
        callback(token.position, token.position + token.length);
      }
    });
  console.log('finished');
}

function keywordStrategy(contentBlock, callback, contentState) {
  if (!finished) return;
  tokens.forEach(token => {
    console.log(token);
  if (token.kind === 'KEYWORD') {
    callback(token.position, token.position + token.length);
  }
});
}

function operatorStrategy(contentBlock, callback, contentState) {
  if (!finished) return;
  tokens.forEach(token => {
    console.log(token);
  if (token.kind === 'OPERATOR') {
    callback(token.position, token.position + token.length);
  }
});
}

function intStrategy(contentBlock, callback, contentState) {
  if (!finished) return;
  tokens.forEach(token => {
    console.log(token);
  if (token.kind === 'INT') {
    callback(token.position, token.position + token.length);
  }
});
}


function findWithRegex(regex, contentBlock, callback) {
  const text = contentBlock.getText();
  let matchArr, start;
  while ((matchArr = regex.exec(text)) !== null) {
    start = matchArr.index;
    callback(start, start + matchArr[0].length);
  }
}

const IdentifierSpan = (props) => {
  return (
    <span
      style={styles.identifier}
      data-offset-key={props.offsetKey}
      >
      {props.children}
    </span>
  );
};

const KeywordSpan = (props) => {
  return (
    <span
      style={styles.keyword}
      data-offset-key={props.offsetKey}
      >
      {props.children}
    </span>
  );
};

const OperatorSpan = (props) => {
  return (
    <span
      style={styles.operator}
      data-offset-key={props.offsetKey}
      >
      {props.children}
    </span>
  );
};

const IntSpan = (props) => {
  return (
    <span
      style={styles.int}
      data-offset-key={props.offsetKey}
      >
      {props.children}
    </span>
  );
};

const styles = {
  root: {
    fontFamily: '"Inconsolata", "Menlo", "Consolas", monospace',
    padding: 20,
    width: 600,
  },
  editor: {
    border: '1px solid #ddd',
    cursor: 'text',
    fontSize: 16,
    minHeight: 40,
    padding: 10,
  },
  button: {
    marginTop: 10,
    textAlign: 'center',
  },
  identifier: {
    color: 'rgba(98, 177, 254, 1.0)',
    direction: 'ltr',
    unicodeBidi: 'bidi-override',
  },
  keyword: {
    color: 'rgba(135, 100, 164, 1.0)',
  },
  operator: {
    color: 'rgba(255, 0, 0, 1.0)',
  },
  int: {
    color: 'rgba(0, 0, 255, 1.0)',
  },
};