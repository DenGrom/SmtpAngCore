import EmailStatus from '../models/enums/email-status.enum'

export class Email {
    id: number
    title: string
    text: string
    emailStatus: EmailStatus
    isActive: boolean
}
