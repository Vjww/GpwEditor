namespace App.BaseGameEditor.Application.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to enable the game's inbuilt track editor.
    /// The modified code sets the flags required to activate the track editor
    /// and force enables track editor key mappings by bypassing file check.
    /// </summary>
    public class TrackEditorFix : DataPatcherUnitBase
    {
        public TrackEditorFix()
        {
            var taskId = 0;

            // Task A
            // Enables track editor mode
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x00450C4F,
                Instructions = new byte[]
                {
                    0x00, 0x00, 0x00, 0x00 // 0
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x00450C4F,
                Instructions = new byte[]
                {
                    0x01, 0x00, 0x00, 0x00 // 1
                }
            });
            // End

            taskId++;

            // Task B
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F4FF,
                Instructions = new byte[]
                {
                    0x68, 0xC0, 0x3A, 0x5F, 0x01, // push    offset aDatYes3ded_dat
                    0xE8, 0xAF, 0x67, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F4FF,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task C
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F536,
                Instructions = new byte[]
                {
                    0x68, 0xD0, 0x3A, 0x5F, 0x01, // push    offset aDatYes3ded_d_0
                    0xE8, 0x78, 0x67, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F536,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task D
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F55F,
                Instructions = new byte[]
                {
                    0x68, 0xE0, 0x3A, 0x5F, 0x01, // push    offset aDatYes3ded_d_1
                    0xE8, 0x4F, 0x67, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F55F,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task E
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F5A8,
                Instructions = new byte[]
                {
                    0x68, 0xF0, 0x3A, 0x5F, 0x01, // push    offset aDatYes3ded_d_2
                    0xE8, 0x06, 0x67, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F5A8,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task F
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F5F1,
                Instructions = new byte[]
                {
                    0x68, 0x00, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded_d_3
                    0xE8, 0xBD, 0x66, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F5F1,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });

            taskId++;

            // Task G
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F655,
                Instructions = new byte[]
                {
                    0x68, 0x10, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded_d_4
                    0xE8, 0x59, 0x66, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F655,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task H
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F69E,
                Instructions = new byte[]
                {
                    0x68, 0x20, 0x3B, 0x5F, 0x01, // offset aDatYes3ded_d_5
                    0xE8, 0x10, 0x66, 0xFE, 0xFF, // sub_435CB8
                    0x83, 0xC4, 0x04              // esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F69E,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task I
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F702,
                Instructions = new byte[]
                {
                    0x68, 0x30, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded_d_6
                    0xE8, 0xAC, 0x65, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F702,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task J
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F74B,
                Instructions = new byte[]
                {
                    0x68, 0x40, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded_d_7
                    0xE8, 0x63, 0x65, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F74B,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task K
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F7AF,
                Instructions = new byte[]
                {
                    0x68, 0x50, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded_d_8
                    0xE8, 0xFF, 0x64, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F7AF,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task L
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F7E4,
                Instructions = new byte[]
                {
                    0x68, 0x60, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded_d_9
                    0xE8, 0xCA, 0x64, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F7E4,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task M
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F859,
                Instructions = new byte[]
                {
                    0x68, 0x70, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__10
                    0xE8, 0x55, 0x64, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F859,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task N
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F882,
                Instructions = new byte[]
                {
                    0x68, 0x80, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__11
                    0xE8, 0x2C, 0x64, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F882,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task O
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F91D,
                Instructions = new byte[]
                {
                    0x68, 0x90, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__12
                    0xE8, 0x91, 0x63, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F91D,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task P
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F966,
                Instructions = new byte[]
                {
                    0x68, 0xA0, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__13
                    0xE8, 0x48, 0x63, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F966,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task Q
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F991,
                Instructions = new byte[]
                {
                    0x68, 0xB0, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__14
                    0xE8, 0x1D, 0x63, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F991,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task R
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F9CA,
                Instructions = new byte[]
                {
                    0x68, 0xC0, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__15
                    0xE8, 0xE4, 0x62, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044F9CA,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task S
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FA2D,
                Instructions = new byte[]
                {
                    0x68, 0xD0, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__16
                    0xE8, 0x81, 0x62, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FA2D,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task T
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FA76,
                Instructions = new byte[]
                {
                    0x68, 0xE0, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__17
                    0xE8, 0x38, 0x62, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FA76,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task U
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FAC6,
                Instructions = new byte[]
                {
                    0x68, 0xF0, 0x3B, 0x5F, 0x01, // push    offset aDatYes3ded__18
                    0xE8, 0xE8, 0x61, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FAC6,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task V
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FAF1,
                Instructions = new byte[]
                {
                    0x68, 0x00, 0x3C, 0x5F, 0x01, // push    offset aDatYes3ded__19
                    0xE8, 0xBD, 0x61, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FAF1,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task W
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FB22,
                Instructions = new byte[]
                {
                    0x68, 0x10, 0x3C, 0x5F, 0x01, // push    offset aDatYes3ded__20
                    0xE8, 0x8C, 0x61, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FB22,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task X
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FB53,
                Instructions = new byte[]
                {
                    0x68, 0x20, 0x3C, 0x5F, 0x01, // push    offset aDatYes3ded__21
                    0xE8, 0x5B, 0x61, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FB53,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task Y
            // Force enable track editor key mappings by bypassing file check
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FB84,
                Instructions = new byte[]
                {
                    0x68, 0x30, 0x3C, 0x5F, 0x01, // push    offset aDatYes3ded__22
                    0xE8, 0x2A, 0x61, 0xFE, 0xFF, // call    sub_435CB8
                    0x83, 0xC4, 0x04              // add     esp, 4
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x0044FB84,
                Instructions = new byte[]
                {
                    0xB8, 0x01, 0x00, 0x00, 0x00, // mov     eax, 1
                    0x90, 0x90, 0x90, 0x90, 0x90, // nop
                    0x90, 0x90, 0x90              // nop
                }
            });
            // End

            taskId++;

            // Task Z
            // Change tga filepath to load track editor enabled reminder image
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x01602A54,
                Instructions = new byte[]
                {
                    // 'tga\backdrop\raceann.tga'
                    0x74, 0x67, 0x61, 0x5C, 0x62, 0x61, 0x63, 0x6B, 0x64, 0x72, 0x6F, 0x70,
                    0x5C, 0x72, 0x61, 0x63, 0x65, 0x61, 0x6E, 0x6E, 0x2E, 0x74, 0x67, 0x61
                    //       r     a     c     e     a     n     n     .     t     g     a
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(TrackEditorFix).Name,
                VirtualPosition = 0x01602A54,
                Instructions = new byte[]
                {
                    // 'tga\backdrop\racetee.tga'
                    0x74, 0x67, 0x61, 0x5C, 0x62, 0x61, 0x63, 0x6B, 0x64, 0x72, 0x6F, 0x70,
                    0x5C, 0x72, 0x61, 0x63, 0x65, 0x74, 0x65, 0x65, 0x2E, 0x74, 0x67, 0x61
                    //       r     a     c     e     t     e     e     .     t     g     a
                }
            });
            // End
        }
    }
}