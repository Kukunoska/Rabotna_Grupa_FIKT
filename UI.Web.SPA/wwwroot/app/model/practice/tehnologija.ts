﻿module app.model {
    "use strict"

    export namespace practice {
        export class Tehnologija {
            public id: number;
            public ime: string;
            public oblastId: Oblast = new Oblast();
        }
    }
}