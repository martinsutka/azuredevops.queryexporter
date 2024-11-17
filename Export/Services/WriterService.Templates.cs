namespace Export.Services
{
    public partial class WriterService
    {
        /// <summary>
        /// Index file template.
        /// </summary>
        public const string IndexTemplate = """
                                            <!doctype html>
                                            <html lang="en">
                                            <head>
                                            	<meta charset="utf-8" />
                                            	<meta name="viewport" content="width=device-width, initial-scale=1" />
                                            	<meta name="description" content="" />
                                            	<title>{{Title}}</title>
                                                <link rel="stylesheet" href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" />
                                                <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700" rel="stylesheet" />
                                                <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
                                                <style>
                                                    html {
                                                        --mdc-theme-background: #1a191e !important;
                                                        --mdc-theme-primary: #cf4901 !important;
                                                        --mdc-theme-secondary: #4ba7b5 !important;

                                                        background: var(--mdc-theme-background);
                                                        color: var(--mdc-theme-text-primary-on-dark);
                                                    }

                                                    .container {
                                                        margin: 0 auto;
                                                        max-width: 1280px;
                                                        width: 90%;
                                                    }

                                                    @media (max-width: 839px) {
                                                        .container {
                                                            width: 98%;
                                                        }
                                                    }

                                                    .mdc-typography--headline4 {
                                                        margin: 0;
                                                    }

                                                    .toc {
                                                        list-style-type: none;
                                                        padding: 0;
                                                    }

                                                    .toc__item {
                                                        display: flex;
                                                        align-items: center;
                                                        line-height: 32px;
                                                    }

                                                    .toc__item a {
                                                        padding: 0px 12px;
                                                        border-radius: 4px;
                                                        position: relative;
                                                        text-decoration: none;
                                                        color: var(--mdc-theme-text-secondary-on-dark);
                                                    }

                                                    .toc__item a:after {
                                                        content: "\00a0";
                                                        background: rgba(0, 0, 0, 0.8);
                                                        position: absolute;
                                                        width: 100%;
                                                        z-index: 0;
                                                        border-radius: 0.25rem;
                                                        transform: scale(0);
                                                        opacity: 0;
                                                        transition: all 0.15s ease;
                                                        left: 0;
                                                    }

                                                    .toc__item a:hover:after {
                                                        transform: scale(1);
                                                        opacity: 1;
                                                    }

                                                    .toc__item a > span {
                                                        z-index: 1;
                                                        position: relative;
                                                    }

                                                    .toc__item a > small {
                                                        z-index: 1;
                                                        position: relative;
                                                        margin-left: 10px;
                                                        color: var(--mdc-theme-secondary);
                                                    }

                                                    .toc__item--level-1 {
                                                        padding-left: 0em;
                                                    }

                                                    .toc__item--level-2 {
                                                        padding-left: 1em;
                                                    }

                                                    .toc__item--level-3 {
                                                        padding-left: 2em;
                                                    }

                                                    .toc__item--level-4 {
                                                        padding-left: 3em;
                                                    }

                                                    .toc__item--level-5 {
                                                        padding-left: 4em;
                                                    }

                                                    .mdc-chip-set {
                                                        padding: 0;
                                                    }

                                                    .mdc-chip {
                                                        pointer-events: none;
                                                        height: 1.5em;
                                                        background: var(--mdc-theme-primary);
                                                        color: var(--mdc-theme-text-primary-on-dark);
                                                    }

                                                    .mdc-chip__text {
                                                        font-size: .8em;
                                                    }

                                                    .comment__count {
                                                        color: var(--mdc-theme-secondary);
                                                        display: flex;
                                                        flex-direction: row;
                                                        align-items: center;
                                                        font-size: .8em;
                                                        margin-left: 10px;
                                                    }
                                                </style>
                                            </head>
                                            <body class="container mdc-typography">
                                                <div class="mdc-layout-grid">
                                                    <div class="mdc-layout-grid__inner">
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                            <h4 class="mdc-typography--headline4">{{Title}}</h4>
                                                        </div>
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                            <ul class="toc">
                                                                {{#each Children}}
                                                                    <li class="toc__item toc__item--level-{{Level}}">
                                                                        <a href="{{Folder}}/index.html"><span>{{Title}}</span><small>{{State}}</small></a>
                                                                        {{#if Tags.Length}}
                                                                            <div class="mdc-chip-set">
                                                                                {{#each Tags}}
                                                                                    <div class="mdc-chip">
                                                                                        <span class="mdc-chip__text">{{this}}</span>
                                                                                    </div>
                                                                                {{/each}}
                                                                            </div>
                                                                        {{/if}}
                                                                        {{#if CommentsCount}}
                                                                        <span class="comment__count"><i class="material-icons">comment</i>&nbsp;{{CommentsCount}}</span>
                                                                        {{/if}}
                                                                        {{#if Attachments.Count}}
                                                                        <span class="comment__count"><i class="material-icons">attachment</i>&nbsp;{{Attachments.Count}}</span>
                                                                        {{/if}}
                                                                    </li>
                                                                {{/each}}
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                            	<script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
                                            </body>
                                            </html>
                                            """;

        /// <summary>
        /// Work item file template.
        /// </summary>
        public const string WorkItemTemplate = """
                                            <!doctype html>
                                            <html lang="en">
                                            <head>
                                            	<meta charset="utf-8" />
                                            	<meta name="viewport" content="width=device-width, initial-scale=1" />
                                            	<meta name="description" content="" />
                                            	<title>{{WorkItem.Title}}</title>
                                                <link rel="stylesheet" href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" />
                                                <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700" rel="stylesheet" />
                                                <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
                                                <style>
                                                    html {
                                                        --mdc-theme-background: #1a191e !important;
                                                        --mdc-theme-primary: #cf4901 !important;
                                                        --mdc-theme-secondary: #4ba7b5 !important;
                                            
                                                        background: var(--mdc-theme-background);
                                                        color: var(--mdc-theme-text-primary-on-dark);
                                                    }

                                                    .container {
                                                        margin: 0 auto;
                                                        max-width: 1280px;
                                                        width: 90%;
                                                    }
                                            
                                                    @media (max-width: 839px) {
                                                        .container {
                                                            width: 98%;
                                                        }
                                                    }

                                                    .mdc-typography--headline4 {
                                                        margin: 0;
                                                    }

                                                    .mdc-chip-set {
                                                        padding: 0;
                                                    }

                                                    .mdc-chip {
                                                        pointer-events: none;
                                                        background: var(--mdc-theme-primary);
                                                        color: var(--mdc-theme-text-primary-on-dark);
                                                    }

                                                    .mdc-chip:first-child {
                                                        margin-left: 0;
                                                    }

                                                    label {
                                                        font-size: .8em;
                                                        font-weight: 500;
                                                        color: var(--mdc-theme-text-secondary-on-dark);
                                                    }

                                                    .comment {
                                                        padding: 10px;
                                                        border-radius: 2px;
                                                        background: var(--mdc-theme-text-secondary-on-light);
                                                    }

                                                    .comment + .comment {
                                                        margin-top: 10px;
                                                    }

                                                    .attachments {
                                                        margin: 0;
                                                        padding: 0;
                                                        list-style-type: none;
                                                    }

                                                    .attachments a {
                                                        text-decoration: none;
                                                        color: var(--mdc-theme-secondary);
                                                    }

                                                    .attachments a:hover {
                                                        text-decoration: underline;
                                                    }
                                                </style>
                                            </head>
                                            <body class="container mdc-typography">
                                                <div class="mdc-layout-grid">
                                                    <div class="mdc-layout-grid__inner">
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                            <button class="mdc-button mdc-button--outlined mdc-button--icon-leading" onclick="history.go(-1)">
                                                                <span class="mdc-button__ripple"></span>
                                                                <span class="mdc-button__focus-ring"></span>
                                                                <i class="material-icons mdc-button__icon" aria-hidden="true">chevron_left</i>
                                                                <span class="mdc-button__label">Back</span>
                                                            </button>
                                                        </div>
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                            <h4 class="mdc-typography--headline4">{{WorkItem.Title}}</h4>
                                                        </div>
                                                        {{#if WorkItem.Tags.Length}}
                                                            <div class="mdc-layout-grid__cell mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                                <div class="mdc-chip-set">
                                                                    {{#each WorkItem.Tags}}
                                                                        <div class="mdc-chip">
                                                                            <span class="mdc-chip__text">{{this}}</span>
                                                                        </div>
                                                                    {{/each}}
                                                                </div>
                                                            </div>
                                                        {{/if}}
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-2">
                                                            <label>Id</label>
                                                            <div>{{WorkItem.Id}}</div>
                                                        </div>
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-2">
                                                            <label>State</label>
                                                            <div>{{WorkItem.State}}</div>
                                                        </div>
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-4">
                                                            <label>Area</label>
                                                            <div>{{WorkItem.NodeName}}</div>
                                                        </div>
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-4">
                                                            <label>Itteration</label>
                                                            <div>{{WorkItem.IterationPath}}</div>
                                                        </div>
                                                        {{#if WorkItem.Description.Length}}
                                                        <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                            <label>Description</label>
                                                            <div class="comment mdc-elevation--z4">{{{WorkItem.Description}}}</div>
                                                        </div>
                                                        {{/if}}
                                                        {{#if WorkItem.Attachments.Count}}
                                                            <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                                <label>Attachments</label>
                                                                <ul class="attachments">
                                                                    {{#each WorkItem.Attachments}}
                                                                        <li><a href="../.attachments/{{FileName}}">{{Name}}</a></li>
                                                                    {{/each}}
                                                                </ul>
                                                            </div>
                                                        {{/if}}
                                                        {{#if Comments.Count}}
                                                            <div class="mdc-layout-grid__cell mdc-layout-grid__cell--span-12">
                                                                <label>Comments</label>
                                                                {{#each Comments}}
                                                                    <div class="comment mdc-elevation--z4">{{{Text}}}</div>
                                                                {{/each}}
                                                            </div>
                                                        {{/if}}
                                                    </div>
                                                </div>
                                            	<script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
                                            </body>
                                            </html>
                                            """;
    }
}
