import { Component, OnInit } from "@angular/core";
import { FormsModule } from "@angular/forms";

class Note {
    id: number;
    title: string;
    content: string;
    createAt: Date;
    constructor(
        id: number,
        title: string,
        content: string,
        createAt: Date) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.createAt = createAt;
    }
}

@Component({
    selector: "app",
    standalone: true,
    imports: [FormsModule],
    styleUrl: "app.style.css",
    templateUrl: "app.template.html",
})
export class AppComponent implements OnInit {
    title: string = "";
    content: string = '';
    noteList: Note[] = [];
    idEdit: number = null;

    convertDate(date: Date) {        
        return date.getDay().toString() + '.' + 
                date.getMonth().toString() + '.' + 
                date.getFullYear().toString() + '\n' +
                date.getHours() + ':' + 
                date.getMinutes();
    }

    ngOnInit() {
        let urlhttps = 'https://localhost:5001/api/note';
        fetch(urlhttps, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            }
        }).then(async response => {
            if (response.ok) {
                response.json().then(results => {
                    for (let result of results) {
                        this.noteList.push(new Note(
                            result['id'],
                            result['title'],
                            result['content'],
                            new Date(result['createAt'])
                        ));
                    }
                });
            }
        });
    }

    closeModal() {
        let modal = document.getElementById('myModal');
        modal.style.display = "none";
    }

    openModalAddNote() {
        this.idEdit = null;
        let modal = document.getElementById('myModal');
        modal.style.display = "block";

        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    }

    openModalEditNote(id: number, title: string, content: string) {
        let modal = document.getElementById('myModal');
        modal.style.display = "block";
        this.idEdit = id;
        this.title = title;
        this.content = content;

        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    }
    addNote(title: string, content: string) {
        let body = {
            "title": title,
            "content": content,
            "tagId": []
        }

        let urlhttps = 'https://localhost:5001/api/note';
        fetch(urlhttps, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(body)
        }).then(async response => {
            if (response.ok)
                response.json().then(result => {
                    this.noteList.push(new Note(
                        result['id'],
                        result['title'],
                        result['content'],
                        new Date(result['createAt'])
                    ));

                });
        });
        this.title = "";
        this.content = "";
        this.closeModal();
    }

    editNote(title: string, content: string) {
        let body = {
            "title": title,
            "content": content,
            "tagId": []
        }

        let urlhttps = 'https://localhost:5001/api/note/' + this.idEdit;
        fetch(urlhttps, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(body)
        }).then(async response => {
            if (response.ok)
                response.json().then(result => {
                    this.noteList.push(new Note(
                        result['id'],
                        result['title'],
                        result['content'],
                        new Date(result['createAt'])
                    ));

                });
        });
        this.title = "";
        this.content = "";
        this.closeModal();
        this.idEdit = null;
    }

    deleteNote(id: number) {
        console.log(id);
        let urlhttps = 'https://localhost:5001/api/note/' + id;
        fetch(urlhttps, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            }
        }).then(async response => {
            if (response.ok) {
                this.noteList = this.noteList.filter(note => note.id !== id);
            }
        });
    }
    sendFilter() { }
}